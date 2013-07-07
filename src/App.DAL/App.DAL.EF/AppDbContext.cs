using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using App.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.DAL.EF
{
    class AppDbContext : DbContext
    {
        internal AppDbContext(string connectionString) : base(connectionString)
        {
            // TODO: Complete member initialization
            Database.SetInitializer<AppDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryRegion>().ToTable("Person.CountryRegion");
            modelBuilder.Entity<CountryRegion>().HasKey(x => x.CountryRegionCode);

            modelBuilder.Entity<StateProvince>().ToTable("Person.StateProvince");
            modelBuilder.Entity<StateProvince>().Property<int>(x => x.ID).HasColumnName("StateProvinceID");
            modelBuilder.Entity<StateProvince>().HasRequired<CountryRegion>(x => x.CountryRegion).WithMany().Map(x => x.MapKey("CountryRegionCode"));

            modelBuilder.Entity<AddressType>().ToTable("Person.AddressType");
            modelBuilder.Entity<AddressType>().Property<int>(x => x.ID).HasColumnName("AddressTypeID");

            modelBuilder.Entity<Address>().ToTable("Person.Address");
            modelBuilder.Entity<Address>().Property<int>(x => x.ID).HasColumnName("AddressID");
            modelBuilder.Entity<Address>().HasRequired<StateProvince>(x => x.StateProvince).WithMany().Map(x => x.MapKey("StateProvinceID"));

            modelBuilder.Entity<DomainBase>().ToTable("Person.BusinessEntity");
            modelBuilder.Entity<DomainBase>().Property<int>(x => x.ID).HasColumnName("BusinessEntityID");

            modelBuilder.Entity<DomainAddress>().ToTable("Person.BusinessEntityAddress");
            modelBuilder.Entity<DomainAddress>().HasKey<int>(x => x.BusinessEntityID);
            modelBuilder.Entity<DomainAddress>().Property<int>(x => x.BusinessEntityID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<DomainAddress>().HasRequired<Address>(x => x.Address).WithMany().Map(x => x.MapKey("AddressID"));
            modelBuilder.Entity<DomainAddress>().HasRequired<AddressType>(x => x.AddressType).WithMany().Map(x => x.MapKey("AddressTypeID"));

            modelBuilder.Entity<Person>().ToTable("Person.Person");
            modelBuilder.Entity<Person>().Property<int>(x => x.ID).HasColumnName("BusinessEntityID");
            modelBuilder.Entity<Person>().Property<int>(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<PersonEmail>().ToTable("Person.EmailAddress");
            modelBuilder.Entity<PersonEmail>().Property<int>(x => x.ID).HasColumnName("EmailAddressID");
            modelBuilder.Entity<PersonEmail>().HasRequired<Person>(x => x.Person).WithMany().Map(x => x.MapKey("BusinessEntityID"));

            modelBuilder.Entity<PhoneNumberType>().ToTable("Person.PhoneNumberType");
            modelBuilder.Entity<PhoneNumberType>().Property<int>(x => x.ID).HasColumnName("PhoneNumberTypeID");

            modelBuilder.Entity<PersonPhone>().ToTable("Person.PersonPhone");
            modelBuilder.Entity<PersonPhone>().HasKey(x => x.PhoneNumber);
            modelBuilder.Entity<PersonPhone>().HasRequired<Person>(x => x.Person).WithMany().Map(x => x.MapKey("BusinessEntityID"));
            modelBuilder.Entity<PersonPhone>().HasRequired<PhoneNumberType>(sp => sp.PhoneNumberType).WithMany().Map(x => x.MapKey("PhoneNumberTypeID"));

            modelBuilder.Entity<ContactType>().ToTable("Person.ContactType");
            modelBuilder.Entity<ContactType>().Property<int>(x => x.ID).HasColumnName("ContactTypeID");

            //modelBuilder.Entity<ContactPerson>().ToTable("Person.BusinessEntityContact");
            //modelBuilder.Entity<ContactPerson>().Property<int>(x => x.ID).HasColumnName("StateProvinceID");

            base.OnModelCreating(modelBuilder);
        }
    }
}
