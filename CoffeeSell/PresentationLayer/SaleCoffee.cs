using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.ObjClass.CoffeeSell.ObjClass;
using CoffeeSell.PresentationLayer;
using CoffeeSell.Ulti;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoffeeSell
{


    public partial class SaleCoffee : Form
    {
        private string selectedSize = "Tất cả";
        private decimal? minPrice = null;
        private decimal? maxPrice = null;
        private System.Windows.Forms.Timer searchTimer;
        private string connectionString = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";
        private int orderIndex = 1;
        private Account user;
        private List<Customer> fullCustomer;
        private DataTable DiscountApplied;

        public SaleCoffee(Account _user)
        {
            this.user = _user;
            InitializeComponent();
            SetupDataGridViewColumns();

            LoadProducts();
            button3.Enabled = false;
            ReloadCustomer();
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            comboBox1.Items.AddRange(new string[] { "A-Z", "Z-A", "Tất cả" });
            comboBox1.SelectedIndex = 0;
            guna2TextBox1.Font = new Font("Segoe UI", 14);
            guna2TextBox1.PlaceholderText = "Tìm kiếm...";
            comboBox2.Items.AddRange(new string[] { "Tất cả", "S", "M", "L" });
            comboBox2.SelectedIndex = 0;

            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += (s, args) =>
            {
                searchTimer.Stop();
                SearchProducts(guna2TextBox1.Text.Trim());
            };

            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            txtKhachHang.ReadOnly= true;


        }
        private void ReloadCustomer()
        {
            fullCustomer = BOCustomer.GetAllCustomerList();

            List<string> phoneNumbers = fullCustomer
             .Where(c => !string.IsNullOrEmpty(c.GetPhoneNumber()))
             .Select(c => c.GetPhoneNumber())
             .ToList();

            // Convert to AutoCompleteStringCollection
            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(phoneNumbers.ToArray());

            // Set up txtSDT for autocomplete
            txtSDT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSDT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSDT.AutoCompleteCustomSource = autoSource;
        }

        private void SetupDataGridViewColumns()
        {
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.AutoGenerateColumns = false;

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderIndex",
                HeaderText = "STT",
                Width = 50
            });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FoodId",
                HeaderText = "Mã food",
                Width = 50
            });
            guna2DataGridView1.Columns["FoodId"].Visible = false;
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Tên sản phẩm",
                Width = 150
            });

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Size",
                HeaderText = "Size",
                Width = 60
            });

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Giá tiền",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Số lượng",
                Width = 80
            });

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Thành tiền",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Width = 75, // Giảm chiều rộng để vừa với nút
                Text = "Sửa", // Giá trị hiển thị trên nút
                UseColumnTextForButtonValue = true // Sử dụng giá trị "Sửa" cho nút
            };
            guna2DataGridView1.Columns.Add(editColumn);

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Width = 75,
                Text = "Xóa",
                UseColumnTextForButtonValue = true
            };
            guna2DataGridView1.Columns.Add(deleteColumn);
        }

        private void LoadProducts(int? categoryId = null)
        {
            string query = categoryId.HasValue
                ? "SELECT * FROM Food WHERE CategoryId = @CategoryId"
                : "SELECT * FROM Food";

            flowLayoutPanelProducts.Controls.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (categoryId.HasValue)
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int foodId = Convert.ToInt32(reader["FoodId"]);
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);

                        ProductUserControl productControl = new ProductUserControl(foodId, productName, price1, price2, price3);
                        productControl.ProductSelected += ProductUserControl_ProductSelected; // Gán sự kiện
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT * FROM Category";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button
                        {
                            Size = guna2Button1.Size,
                            FillColor = guna2Button1.FillColor,
                            Font = guna2Button1.Font,
                            ForeColor = guna2Button1.ForeColor,
                            BorderRadius = guna2Button1.BorderRadius,
                            TextAlign = guna2Button1.TextAlign,
                            Cursor = guna2Button1.Cursor,
                            Margin = guna2Button1.Margin,
                            Padding = guna2Button1.Padding
                        };
                        b.HoverState.FillColor = guna2Button1.HoverState.FillColor;
                        b.HoverState.ForeColor = guna2Button1.HoverState.ForeColor;
                        b.HoverState.BorderColor = guna2Button1.HoverState.BorderColor;

                        b.Text = reader["NameCategory"].ToString();
                        b.Tag = Convert.ToInt32(reader["CategoryId"]);
                        b.Click += CategoryButton_Click;
                        flowLayoutPanelCategories.Controls.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton == null) return;

            int categoryId = (int)clickedButton.Tag;
            LoadProducts(categoryId);
        }

        private void SearchProducts(string keyword)
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear();
                string query = string.IsNullOrEmpty(keyword)
                    ? "SELECT * FROM Food"
                    : "SELECT * FROM Food WHERE NameFood LIKE @keyword";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (!string.IsNullOrEmpty(keyword))
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int foodId = Convert.ToInt32(reader["FoodId"]);
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);

                        ProductUserControl productControl = new ProductUserControl(foodId, productName, price1, price2, price3);
                        productControl.ProductSelected += ProductUserControl_ProductSelected; // Gán sự kiện
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductUserControl_ProductSelected(object sender, FoodInCart foodInCart)
        {
            MessageBox.Show($"Thêm sản phẩm: {foodInCart.NameFood}, Size: {foodInCart.Size}, Giá: {foodInCart.Price:N0} VNĐ", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["ProductName"].Value?.ToString() == foodInCart.NameFood &&
                    row.Cells["Size"].Value?.ToString() == foodInCart.Size)
                {
                    int currentQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = currentQuantity + 1;
                    row.Cells["Total"].Value = (currentQuantity + 1) * foodInCart.Price;
                    UpdateTotalLabel();
                    return;
                }
            }

            guna2DataGridView1.Rows.Add(
                orderIndex++,
                foodInCart.FoodId,
                foodInCart.NameFood,
                foodInCart.Size,
                foodInCart.Price,
                foodInCart.Quantity,
                foodInCart.Price * foodInCart.Quantity,
                "Sửa",
                "Xóa"
            );
            UpdateTotalLabel();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                // Xử lý nút "Sửa"
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string productName = guna2DataGridView1.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    decimal price = Convert.ToDecimal(guna2DataGridView1.Rows[e.RowIndex].Cells["Price"].Value);

                    string input = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Nhập số lượng mới cho {productName}:",
                        "Sửa số lượng",
                        guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()
                    );

                    if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
                    {
                        guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = newQuantity;
                        guna2DataGridView1.Rows[e.RowIndex].Cells["Total"].Value = newQuantity * price;
                        UpdateTotalLabel();
                    }
                    else if (!string.IsNullOrEmpty(input))
                    {
                        MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Xử lý nút "Xóa" (trừ 1 đơn vị số lượng)
                else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int currentQuantity = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                    if (currentQuantity > 1)
                    {
                        // Trừ 1 đơn vị số lượng
                        guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = currentQuantity - 1;
                        decimal price = Convert.ToDecimal(guna2DataGridView1.Rows[e.RowIndex].Cells["Price"].Value);
                        guna2DataGridView1.Rows[e.RowIndex].Cells["Total"].Value = (currentQuantity - 1) * price;
                        UpdateTotalLabel();
                    }
                    else
                    {
                        // Nếu số lượng là 1, xóa dòng
                        guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                        // Cập nhật lại số thứ tự
                        orderIndex = 1;
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            row.Cells["OrderIndex"].Value = orderIndex++;

                        }
                        UpdateTotalLabel();
                    }
                }
            }
            catch (Exception ex) { }
        }



        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedOption)) return;

            try
            {
                flowLayoutPanelProducts.Controls.Clear();
                string query = "SELECT * FROM Food";

                if (selectedOption == "A-Z")
                    query += " ORDER BY NameFood ASC";
                else if (selectedOption == "Z-A")
                    query += " ORDER BY NameFood DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int foodId = Convert.ToInt32(reader["FoodId"]);
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);

                        ProductUserControl productControl = new ProductUserControl(foodId, productName, price1, price2, price3);
                        productControl.ProductSelected += ProductUserControl_ProductSelected;
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTotalLabel()
        {
            decimal total = 0;
            decimal discount = 0;
            decimal finalPrice = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["Total"].Value != null && decimal.TryParse(row.Cells["Total"].Value.ToString().Replace(" VNĐ", "").Replace(",", ""), out decimal rowTotal))
                {
                    total += rowTotal;
                }
            }
            if(DiscountApplied !=null)
            {
                int totalDiscount = 0;
                foreach(DataRow row in DiscountApplied.Rows)
                {
                    totalDiscount += Convert.ToInt32(row["DiscountPercent"]);
                }
                discount = Math.Min((totalDiscount * total) / 100, total);
            }
            finalPrice = total - discount;

            lblTien.Text = total.ToString("N0") + " VNĐ"; // Hiển thị tổng tiền với định dạng
            lblTienGiam.Text = discount.ToString("N0") + "VNĐ";
            labeltotal.Text = finalPrice.ToString("N0") + "VNĐ";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSize = comboBox2.SelectedItem?.ToString() ?? "Tất cả";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal price))
                minPrice = price;
            else
                minPrice = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox2.Text, out decimal price))
                maxPrice = price;
            else
                maxPrice = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear();
                string query = "SELECT * FROM Food";
                var conditions = new List<string>();
                string priceColumn = selectedSize == "S" ? "Price_S" :
                                    selectedSize == "M" ? "Price_M" :
                                    selectedSize == "L" ? "Price_L" : null;

                if (minPrice.HasValue)
                {
                    if (priceColumn != null)
                        conditions.Add($"{priceColumn} >= @minPrice");
                    else
                        conditions.Add("(Price_S >= @minPrice OR Price_M >= @minPrice OR Price_L >= @minPrice)");
                }
                if (maxPrice.HasValue)
                {
                    if (priceColumn != null)
                        conditions.Add($"{priceColumn} <= @maxPrice");
                    else
                        conditions.Add("(Price_S <= @maxPrice OR Price_M <= @maxPrice OR Price_L <= @maxPrice)");
                }

                if (conditions.Count > 0)
                    query += " WHERE " + string.Join(" AND ", conditions);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (minPrice.HasValue)
                        cmd.Parameters.AddWithValue("@minPrice", minPrice.Value);
                    if (maxPrice.HasValue)
                        cmd.Parameters.AddWithValue("@maxPrice", maxPrice.Value);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int foodId = Convert.ToInt32(reader["FoodId"]);
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);

                        ProductUserControl productControl = new ProductUserControl(foodId, productName, price1, price2, price3);
                        productControl.ProductSelected += ProductUserControl_ProductSelected;
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaleCoffee_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            // Đặt lại orderIndex về 1
            orderIndex = 1;
            UpdateTotalLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer customerinfo = new Customer();
            customerinfo.SetNameCustomer(txtKhachHang.Text);
            customerinfo.SetPhoneNumber(txtSDT.Text);
            bool exists = fullCustomer.Any(cus => cus.GetPhoneNumber() == txtSDT.Text);
            if (exists)
            {
                customerinfo = fullCustomer.FirstOrDefault(cus => cus.GetPhoneNumber() == txtSDT.Text);
            }
            else if (txtSDT.Text != "")
            {
                customerinfo.SetCustomerId(BOCustomer.Add(customerinfo));
                customerinfo.SetPoints(0);
                MessageBox.Show(customerinfo.GetCustomerId().ToString());
                ReloadCustomer();
            }
            else
            {
                customerinfo.SetCustomerId(-1);
            }
            string cleaned = labeltotal.Text.Replace("VNĐ", "").Trim();

            // Remove thousand separator
            cleaned = cleaned.Replace(",", "");

            // Parse to decimal
            decimal price = decimal.Parse(cleaned);
            string cleanedd = lblTien.Text.Replace("VNĐ", "").Trim();

            // Remove thousand separator
            cleanedd = cleanedd.Replace(",", "");

            // Parse to decimal
            decimal pricee = decimal.Parse(cleanedd);

            string cleaneddd = lblTienGiam.Text.Replace("VNĐ", "").Trim();

            // Remove thousand separator
            cleaneddd = cleaneddd.Replace(",", "");

            // Parse to decimal
            decimal priceee = decimal.Parse(cleaneddd);

            if (price > 0)
            {
                Bill bill = new Bill();
                bill.CustomerId = customerinfo.GetCustomerId() == -1 ? null : customerinfo.GetCustomerId();
                bill.TotalPrice = price;

                decimal TienDua =0;
                ThoiTienForm tempForm = new ThoiTienForm(price);
                if(tempForm.ShowDialog() == DialogResult.OK )
                {
                    TienDua = tempForm.TienDua;
                }
                decimal TienThoi = TienDua - price;
                Receipt receipt = new Receipt();
                receipt.receive = TienDua;
                receipt.changeDue = TienThoi;
                receipt.totalPrice = pricee;
                receipt.totalDiscount = priceee;
                receipt.finalPrice = price;
                bill.BillId = BOBill.Add(bill);
                receipt.id = bill.BillId;
                if (bill.BillId > 0)
                {
                    List<Products> list = new List<Products>();
                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        BillInfo billInfo = new BillInfo();
                        billInfo.SetIdBill(bill.BillId);
                        billInfo.SetIdFood(Convert.ToInt32(row.Cells["FoodId"].Value));
                        billInfo.SetQuantity(Convert.ToInt32(row.Cells["Quantity"].Value));
                        string productName = row.Cells["ProductName"].Value?.ToString() ?? "";
                        string size = row.Cells["Size"].Value?.ToString() ?? "";
                        string fullName = productName + "-" + size;

                        decimal pricextz = 0;
                        if (decimal.TryParse(row.Cells["Total"].Value?.ToString(), out decimal parsedPrice))
                            pricextz = parsedPrice;
                        // Else keep price = 0 or handle error accordingly

                        Products product = new Products(
                            fullName,
                            billInfo.GetQuantity(),
                            pricextz
                        );


                        list.Add(product);
                        if (billInfo.GetIdFood() == 0)
                            break;
                        if (!BOBIllInfo.Add(billInfo))
                        {
                            MessageBox.Show("Có lỗi xãy ra!");
                            return;
                        }
                    }
                    receipt.Items = list;
                    string path = PhotoFunction.GenerateReceipt(receipt, user.GetLoginName(), customerinfo);
                    BOBill.UpdatePhoto(bill.BillId, path);
                   
                    if(DiscountApplied!=null)
                    {
                        
                        foreach(DataRow row in DiscountApplied.Rows)
                        {
                            decimal sv = pricee * (decimal)row["DiscountPercent"] / 100;
                            DiscountBillInfo billInfo = new DiscountBillInfo();
                            billInfo.SetSaved(sv);
                            billInfo.SetBillId(bill.BillId);
                            billInfo.SetDiscountId((int)row["DiscountId"]);
                            if(!BOBillDiscountInfo.Add(billInfo))
                            {
                                MessageBox.Show("SOS");
                            }
                            if (!(bool)row["IsReuseable"])
                            {
                                UsedDiscount newDiscount = new UsedDiscount();
                                newDiscount.SetDiscountId((int)row["DiscountId"]);
                                newDiscount.SetCustomerId(customerinfo.GetCustomerId());
                                BOUsedDiscount.Add(newDiscount);
                            }
                        }
                    }
                    if (customerinfo.GetCustomerId() != -1)
                    { BOCustomer.UpdatePoint(customerinfo.GetCustomerId(), (int)price); }

                    MessageBox.Show("Thanh toán thành công");
                    guna2DataGridView1.Rows.Clear();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer customerinfo = new Customer();
            customerinfo.SetNameCustomer(txtKhachHang.Text);
            customerinfo.SetPhoneNumber(txtSDT.Text);
            bool exists = fullCustomer.Any(cus => cus.GetPhoneNumber() == txtSDT.Text);
            if (exists)
            {
                customerinfo = fullCustomer.FirstOrDefault(cus => cus.GetPhoneNumber() == txtSDT.Text);
            }
            else if (txtSDT.Text != "")
            {
                customerinfo.SetCustomerId(BOCustomer.Add(customerinfo));
                ReloadCustomer();
            }
            else
            {
                customerinfo.SetCustomerId(-1);
            }
            KhuyenMaiSellect kmForm = new KhuyenMaiSellect(customerinfo.GetCustomerId());
            if (kmForm.ShowDialog() == DialogResult.OK)
            {
                DiscountApplied = kmForm.ChoosenDiscount;
            }
            UpdateTotalLabel();
        }


        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            DiscountApplied = null;
            Customer customerinfo = fullCustomer.FirstOrDefault(cus => cus.GetPhoneNumber() == txtSDT.Text);
            if (customerinfo != null)
            {

                txtKhachHang.Text = customerinfo.GetNameCustomer();
                txtKhachHang.ReadOnly = true;
                button3.Enabled = true;
            }
            else if(txtSDT.Text.Length!=10)
            {
                txtKhachHang.Text = "";
                txtKhachHang.ReadOnly = true;
                button3.Enabled = false;
            }
            else
            {
                txtKhachHang.ReadOnly = false;
                button3.Enabled = true;
            }
        }
    }
}