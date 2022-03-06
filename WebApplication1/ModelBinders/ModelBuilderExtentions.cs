using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ModelBinders
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderInformations>().HasData(
                new GenderInformations { Id = 1, GenderName = "Male" },
                new GenderInformations { Id = 2, GenderName = "Female" }
            );

            modelBuilder.Entity<UserInformation>()
                .HasOne(p => p.Gender)
                .WithMany(q => q.UserInformations)
                .HasForeignKey(r => r.GenderId);

            modelBuilder.Entity<UserInformation>().HasData(
               new UserInformation
               {
                   Id = 1,
                   FullName = "Admin",
                   UserName = "admin@gmail.com",
                   UserPassword = "12345678",
                   GenderId = 1,
                   IsActive = true,
                   CreatedDate = System.DateTime.Now
               });

            modelBuilder.Entity<DepartmentInformations>()
                .HasData(new DepartmentInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    Name = "Accounting"
                });

            modelBuilder.Entity<DepartmentInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.DepartmentInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<DesignationInformations>()
               .HasOne(p => p.UserInformation)
               .WithMany(q => q.DesignationInformations)
               .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<VehicleInformation>()
               .HasOne(p => p.UserInformation)
               .WithMany(q => q.VehicleInformation)
               .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<VehicleInformation>()
               .HasOne(p => p.VehicleTypeInformations)
               .WithMany(q => q.VehicleInformation)
               .HasForeignKey(x => x.VehicleTypeId);

            modelBuilder.Entity<VehicleInformation>()
                .HasData(new VehicleInformation
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    Model = "2008",
                    VehicleTypeId = 1,
                    Color = "Red",
                    Brand = "Toyota",
                    InsuranceExpiry = System.DateTime.Now,
                    MulkiyaExpiry = System.DateTime.Now,
                    PlateNumber = "2005",
                    Comments = "this from seed for test",
                    RegisterdRegion = "Abu Dhabi",
                    TCNumber = "13131"
                });

            modelBuilder.Entity<DesignationInformations>()
                .HasData(new DesignationInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    Name = "Driver"
                });

            modelBuilder.Entity<BloodGroupInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.BloodGroupInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<UnitInformations>()
               .HasData(new UnitInformations
               {
                   Id = 1,
                   CreatedBy = 1,
                   CreatedDate = System.DateTime.Now,
                   IsActive = true,
                   Name = "Letter"
               });

            modelBuilder.Entity<UnitInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.UnitInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<ProductInfo>()
               .HasData(new ProductInfo
               {
                   Id = 1,
                   CreatedBy = 1,
                   UnitId = 1,
                   Description = "this is from seed,for test purpose",
                   CreatedDate = System.DateTime.Now,
                   IsActive = true,
                   Name = "Letter"
               });

            modelBuilder.Entity<ProductInfo>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.ProductInfos)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<ProductInfo>()
                .HasOne(p => p.UnitInformations)
                .WithMany(q => q.ProductInfos)
                .HasForeignKey(x => x.UnitId);

            modelBuilder.Entity<CustomerInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.CustomerInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<CustomerInformations>()
               .HasData(new CustomerInformations
               {
                   Id = 1,
                   CompanyName = "Test Name",
                   ContactPersonName = "Seed Name",
                   Country = "UAE",
                   TRNNumber = "123456789123456",
                   MobileNumber = "121313454112",
                   LandLine = "34564613564",
                   Address = "nest 18, street k5 Allon",
                   Area = "Mufraq",
                   State = "Abu Dhabi",
                   Description = "this is test description from seed",
                   Email = "this@test.com",
                   CreatedBy = 1,
                   CreatedDate = System.DateTime.Now,
                   IsActive = true
               });

            modelBuilder.Entity<VenderInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.VenderInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<VenderInformations>()
              .HasData(new VenderInformations
              {
                  Id = 1,
                  CompanyName = "Test Vender",
                  ContactPersonName = "Seed Vender",
                  Country = "UAE",
                  TRNNumber = "123456789123456",
                  MobileNumber = "121313454112",
                  LandLine = "34564613564",
                  Address = "nest 18, street k5 Allon",
                  Area = "Mufraq",
                  State = "Abu Dhabi",
                  Description = "this is test description from seed",
                  Email = "this@test.com",
                  CreatedBy = 1,
                  CreatedDate = System.DateTime.Now,
                  IsActive = true
              });

            modelBuilder.Entity<BloodGroupInformations>()
                .HasData(new BloodGroupInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    Name = "A+"
                });

            modelBuilder.Entity<VehicleTypeInformations>()
                .HasData(new VehicleTypeInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    TypeName = "Heavy Vehicle"
                });

            modelBuilder.Entity<VehicleTypeInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.VehicleTypeInformations)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<EmployeeInformations>()
                .HasOne(p => p.UserInformation)
                .WithMany(q => q.EmployeeInformations)
                .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<EmployeeInformations>()
               .HasOne(p => p.DepartmentInformations)
               .WithMany(q => q.EmployeeInformations)
               .HasForeignKey(r => r.DepartmentId);

            modelBuilder.Entity<EmployeeInformations>()
              .HasOne(p => p.DesignationInformations)
              .WithMany(q => q.EmployeeInformations)
              .HasForeignKey(r => r.DesignationId);

            modelBuilder.Entity<EmployeeInformations>()
              .HasOne(p => p.BloodGroupInformations)
              .WithMany(q => q.EmployeeInformations)
              .HasForeignKey(r => r.BloodGroupId);

            modelBuilder.Entity<EmployeeInformations>()
              .HasOne(p => p.GenderInformations)
              .WithMany(q => q.EmployeeInformations)
              .HasForeignKey(r => r.GenderId);

            modelBuilder.Entity<EmployeeInformations>()
               .HasData(
               new EmployeeInformations
               {
                   Id = 1,
                   CreatedBy = 1,
                   Name = "Test Name",
                   Address = "jos 10 faren street s6, no 1099",
                   Age = 25,
                   BloodGroupId = 1,
                   CreatedDate = System.DateTime.Now,
                   DateofBirth = System.DateTime.Now,
                   DepartmentId = 1,
                   Description = "this is test Employee From Seed",
                   DesignationId = 1,
                   EmailAddress = "test@gmail.com",
                   GenderId = 1,
                   HireDate = System.DateTime.Now,
                   ImageUrl = "jas.jpg",
                   IsActive = true,
                   MobileNumber = "1231464612",
                   EmergencyContactNumber = "64648464412",
                   IdCardExpiry = System.DateTime.Now,
                   VisaExpiry = System.DateTime.Now,
                   PassportExpiry = System.DateTime.Now,
                   DrivingLicienceExpiry = System.DateTime.Now

               });

            modelBuilder.Entity<TrackUpdateInformations>()
            .HasOne(p => p.UserInformation)
            .WithMany(q => q.TrackUpdateInformations)
            .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<TrackUpdateInformations>()
                .HasData(new TrackUpdateInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    UpdateInfo = "Driver Update to Driver Name",
                    BeforeUpdate = "Driver",
                    AfterUpdate = "Driver Name"
                });

            modelBuilder.Entity<ControlAccountInformations>()
           .HasOne(p => p.UserInformation)
           .WithMany(q => q.ControlAccountInformations)
           .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<ControlAccountInformations>()
                .HasData(new ControlAccountInformations
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    ControlAccountName = "ASSETS",
                    Code = 1001
                });

            modelBuilder.Entity<HeadAccountsInformations>()
           .HasOne(p => p.UserInformation)
           .WithMany(q => q.HeadAccountsInformations)
           .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<HeadAccountsInformations>()
          .HasOne(p => p.ControlAccountInformations)
          .WithMany(q => q.HeadAccountsInformations)
          .HasForeignKey(r => r.ControlAccountId);

            modelBuilder.Entity<HeadAccountsInformations>()
                .HasData(new HeadAccountsInformations
                {
                    Id = 1,
                    HeadAccountTitle = "Current Assets",
                    ControlAccountId = 1,
                    Code = 1001,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                });

            modelBuilder.Entity<AccountsInformation>()
           .HasOne(p => p.UserInformation)
           .WithMany(q => q.AccountsInformation)
           .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<AccountsInformation>()
          .HasOne(p => p.HeadAccountsInformations)
          .WithMany(q => q.AccountsInformations)
          .HasForeignKey(r => r.HeadAccountId);

            modelBuilder.Entity<AccountsInformation>()
                .HasData(new AccountsInformation
                {
                    Id = 1,
                    AccountTitle = "Petty cash",
                    HeadAccountId = 1,
                    Code = 10001,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                });

            modelBuilder.Entity<TransictionInformations>()
          .HasOne(p => p.UserInformation)
          .WithMany(q => q.TransictionInformations)
          .HasForeignKey(r => r.CreatedBy);
             
            modelBuilder.Entity<TransictionInformations>()
          .HasOne(p => p.AccountsInformation)
          .WithMany(q => q.TransictionInformations)
          .HasForeignKey(r => r.AccountId);

            modelBuilder.Entity<TransictionInformations>()
                .HasData(new TransictionInformations
                {
                    Id = 1,
                    AccountId = 2,
                    Dr = 5000,
                    Cr = 0,
                    ForDate = System.DateTime.Now,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    Description = "Owner invest as a cash",
                    TransictionIdentity = 1245654284
                },
                         new TransictionInformations
                         {

                             Id = 2,
                             AccountId = 1020,
                             Dr = 0,
                             Cr = 5000,
                             ForDate = System.DateTime.Now,
                             CreatedBy = 1,
                             CreatedDate = System.DateTime.Now,
                             IsActive = true,
                             Description = "Owner invest as a cash",
                             TransictionIdentity = 1245654284
                         });

            modelBuilder.Entity<QuotationInformation>()
          .HasOne(p => p.UserInformation)
          .WithMany(q => q.QuotationInformation)
          .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<QuotationInformation>()
          .HasOne(p => p.CustomerInformations)
          .WithMany(q => q.QuotationInformation)
          .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<QuotationInformation>()
                .HasData(new QuotationInformation
                {
                    Id = 1,
                    CustomerId = 1,
                    TotalAmount = 100,
                    VAT = 5,
                    GrandTotalAmount = 105,
                    FromDate = System.DateTime.Now,
                    DueDate = System.DateTime.Now,
                    CustomerNote = "This is test from seed",
                    TermCondition = "This is Term Condition from seed",
                    QuotationNumber = 1232154545,
                    ISConverted = false,
                    IsNeedSignature = false,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true
                });

            modelBuilder.Entity<QuotationDetails>()
          .HasOne(p => p.QuotationInformation)
          .WithMany(q => q.QuotationDetails)
          .HasForeignKey(r => r.QuotationId);

            modelBuilder.Entity<QuotationDetails>()
          .HasOne(p => p.ProductInfo)
          .WithMany(q => q.QuotationDetails)
          .HasForeignKey(r => r.ItemId);

            modelBuilder.Entity<QuotationDetails>()
             .HasOne(p => p.UnitInformations)
             .WithMany(q => q.QuotationDetails)
             .HasForeignKey(r => r.UnitId);

            modelBuilder.Entity<QuotationDetails>()
          .HasData(new QuotationDetails()
         {
             Id = 1,
             QuotationId = 1,
             ItemId = 1,
             UnitId = 1,
             Description = "this one item from seed",
             Quantity = 5,
             UnitPrice = 20,
             Total = 100,
             VAT = 5,
             SubTotal = 105
         });

            modelBuilder.Entity<PaymentTypeInformations>()
            .HasOne(p => p.UserInformation)
            .WithMany(q => q.PaymentTypeInformations)
            .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<PaymentTypeInformations>()
                .HasData(new PaymentTypeInformations
                {
                    Id = 1,
                    TypeName = "Cash",
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                });

            modelBuilder.Entity<ExpenseInformation>()
           .HasOne(p => p.UserInformation)
           .WithMany(q => q.ExpenseInformation)
           .HasForeignKey(r => r.CreatedBy);

            modelBuilder.Entity<ExpenseInformation>()
           .HasOne(p => p.PaymentTypeInformations)
           .WithMany(q => q.ExpenseInformations)
           .HasForeignKey(r => r.PaymentType);

            modelBuilder.Entity<ExpenseInformation>()
              .HasOne(p => p.VenderInformations)
              .WithMany(q => q.ExpenseInformations)
              .HasForeignKey(r => r.VenderId);

            modelBuilder.Entity<ExpenseInformation>()
             .HasOne(p => p.EmployeeInformations)
             .WithMany(q => q.ExpenseInformation)
             .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<ExpenseDetailsInformations>()
             .HasOne(p => p.ExpenseInformation)
             .WithMany(q => q.ExpenseDetailsInformations)
             .HasForeignKey(r => r.ExpenseId);

            modelBuilder.Entity<ExpenseDetailsInformations>()
             .HasOne(p => p.ProductInfo)
             .WithMany(q => q.ExpenseDetailsInformations)
             .HasForeignKey(r => r.GeneralExpenseId);

            modelBuilder.Entity<ExpenseDetailsInformations>()
             .HasOne(p => p.vehicleInformation)
             .WithMany(q => q.ExpenseDetailsInformations)
             .HasForeignKey(r => r.VehicleId);

            modelBuilder.Entity<ExpenseDetailsInformations>()
             .HasOne(p => p.EmployeeInformations)
             .WithMany(q => q.ExpenseDetailsInformations)
             .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<ExpenseInformation>()
                .HasData(new ExpenseInformation
                {
                    Id = 1,
                    EmployeeId = 1,
                    VenderId = 1,
                    TotalAmount = 200,
                    VAT = 10,
                    GrandTotalAmount = 210,
                    SpecialNote = "This is note from seed",
                    ExpenseDate = System.DateTime.Now,
                    PaymentType = 1,
                    ExpenseNumber = 100121,
                    IsApproved = false,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                });

            modelBuilder.Entity<ExpenseDetailsInformations>()
                .HasData(new ExpenseDetailsInformations
                {
                    Id = 1,
                    EmployeeId = 1,
                    ExpenseId = 1,
                    OnDate = System.DateTime.Now,
                    ExpenseRefrenceId = 1,
                    Description = "this is employee expense",
                    GeneralExpenseId = 1,
                    Category = "Employee",
                    SubTotal = 100,
                    VAT = 5,
                    NetTotal = 105,
                    VehicleId = 1                    
                });

        }
    }
}
