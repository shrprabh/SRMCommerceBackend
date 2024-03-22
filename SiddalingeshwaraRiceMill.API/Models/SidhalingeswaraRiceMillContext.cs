using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class SidhalingeswaraRiceMillContext : DbContext
{
    public SidhalingeswaraRiceMillContext()
    {
    }

    public SidhalingeswaraRiceMillContext(DbContextOptions<SidhalingeswaraRiceMillContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressTbl> AddressTbls { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryTable> DeliveryTables { get; set; }

    public virtual DbSet<DepartmentTbl> DepartmentTbls { get; set; }

    public virtual DbSet<EmployeeTbl> EmployeeTbls { get; set; }

    public virtual DbSet<LocationDatum> LocationData { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<ProductTbl> ProductTbls { get; set; }

    public virtual DbSet<RoleTbl> RoleTbls { get; set; }

    public virtual DbSet<SalaryTbl> SalaryTbls { get; set; }

    public virtual DbSet<ShippingTable> ShippingTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 => optionsBuilder.UseMySQL("Server=localhost;Database=SidhalingeswaraRiceMill;Uid=root;Pwd=Project@2023;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTbl>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("Address_tbl", "SidhalingeswaraRiceMill");

            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.EntityId).HasColumnName("Entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .HasColumnName("Entity_type");
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.Property(e => e.Pincode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(255);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.ToTable("Cart", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.CustomerId, "Customer_id");

            entity.HasIndex(e => e.ProductId, "Product_id");

            entity.Property(e => e.CartId).HasColumnName("Cart_id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("date")
                .HasColumnName("Added_date");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("cart_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("cart_ibfk_2");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("Customers", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.AddressId, "Address_id");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.Gmail).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("customers_ibfk_1");
        });

        modelBuilder.Entity<DeliveryTable>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PRIMARY");

            entity.ToTable("Delivery_table", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.CustomerId, "Customer_id");

            entity.HasIndex(e => e.OrderId, "Order_id");

            entity.HasIndex(e => e.ShippingId, "Shipping_id");

            entity.Property(e => e.DeliveryId).HasColumnName("Delivery_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ShippingId).HasColumnName("Shipping_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.DeliveryTables)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("delivery_table_ibfk_1");

            entity.HasOne(d => d.Order).WithMany(p => p.DeliveryTables)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("delivery_table_ibfk_2");

            entity.HasOne(d => d.Shipping).WithMany(p => p.DeliveryTables)
                .HasForeignKey(d => d.ShippingId)
                .HasConstraintName("delivery_table_ibfk_3");
        });

        modelBuilder.Entity<DepartmentTbl>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("Department_tbl", "SidhalingeswaraRiceMill");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("Contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(15)
                .HasColumnName("Contact_phone");
            entity.Property(e => e.DepartmentLocation)
                .HasMaxLength(255)
                .HasColumnName("Department_location");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .HasColumnName("Department_name");
        });

        modelBuilder.Entity<EmployeeTbl>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("Employee_tbl", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.AddressId, "Address_id");

            entity.HasIndex(e => e.DepartmentId, "Department_id");

            entity.HasIndex(e => e.Role, "Role");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_id");
            entity.Property(e => e.DobDay).HasColumnName("Dob_day");
            entity.Property(e => e.DobMonth).HasColumnName("Dob_month");
            entity.Property(e => e.DobYear).HasColumnName("Dob_year");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .HasColumnName("Employee_name");
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.Address).WithMany(p => p.EmployeeTbls)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("employee_tbl_ibfk_3");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeTbls)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employee_tbl_ibfk_2");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.EmployeeTbls)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("employee_tbl_ibfk_1");
        });

        modelBuilder.Entity<LocationDatum>(entity =>
        {
            entity.HasKey(e => e.Pincode).HasName("PRIMARY");

            entity.ToTable("Location_data", "SidhalingeswaraRiceMill");

            entity.Property(e => e.Pincode).HasMaxLength(20);
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .HasColumnName("City_name");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("Country_name");
            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .HasColumnName("State_name");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("Orders_tbl", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.CustomerId, "Customer_id");

            entity.HasIndex(e => e.EmployeeId, "Employee_id");

            entity.HasIndex(e => e.ProductId, "Product_id");

            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.Cost).HasPrecision(10);
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("Order_date");
            entity.Property(e => e.OrderDay).HasColumnName("Order_day");
            entity.Property(e => e.OrderMonth).HasColumnName("Order_month");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("Order_status");
            entity.Property(e => e.OrderYear).HasColumnName("Order_year");
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.ShippingId).HasColumnName("Shipping_id");
            entity.Property(e => e.Tax).HasPrecision(10);
            entity.Property(e => e.Total).HasPrecision(10);

            entity.HasOne(d => d.Customer).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("orders_tbl_ibfk_3");

            entity.HasOne(d => d.Employee).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("orders_tbl_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("orders_tbl_ibfk_1");
        });

        modelBuilder.Entity<ProductTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("Product_tbl", "SidhalingeswaraRiceMill");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.ProductDescription)
                .HasColumnType("text")
                .HasColumnName("Product_description");
            entity.Property(e => e.ProductType)
                .HasMaxLength(255)
                .HasColumnName("Product_type");
            entity.Property(e => e.QuantityAvailable).HasColumnName("Quantity_available");
        });

        modelBuilder.Entity<RoleTbl>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("Role_tbl", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.DeptId, "Dept_id");

            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.DeptId).HasColumnName("Dept_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("Role_name");

            entity.HasOne(d => d.Dept).WithMany(p => p.RoleTbls)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("role_tbl_ibfk_1");
        });

        modelBuilder.Entity<SalaryTbl>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PRIMARY");

            entity.ToTable("Salary_tbl", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.EmployeeId, "Employee_id");

            entity.Property(e => e.SalaryId).HasColumnName("Salary_id");
            entity.Property(e => e.Bonus).HasPrecision(10);
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.Salary).HasPrecision(10);
            entity.Property(e => e.SalaryDate)
                .HasColumnType("date")
                .HasColumnName("Salary_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.SalaryTbls)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("salary_tbl_ibfk_1");
        });

        modelBuilder.Entity<ShippingTable>(entity =>
        {
            entity.HasKey(e => e.ShippingId).HasName("PRIMARY");

            entity.ToTable("Shipping_table", "SidhalingeswaraRiceMill");

            entity.HasIndex(e => e.OrderId, "Order_id");

            entity.Property(e => e.ShippingId).HasColumnName("Shipping_id");
            entity.Property(e => e.ActualDeliveryDate)
                .HasColumnType("date")
                .HasColumnName("Actual_delivery_date");
            entity.Property(e => e.EstimatedDeliveryDate)
                .HasColumnType("date")
                .HasColumnName("Estimated_delivery_date");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ShippingDate)
                .HasColumnType("date")
                .HasColumnName("Shipping_date");
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(50)
                .HasColumnName("Shipping_status");

            entity.HasOne(d => d.Order).WithMany(p => p.ShippingTables)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("shipping_table_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
