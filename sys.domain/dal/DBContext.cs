using sys.domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;


namespace sys.domain.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(connection_string conn)
            : base(conn.connection)
        {
            Database.SetInitializer<DBContext>(null);
        }

        public DbSet<dbs.Categories> Categories { get; set; }
        public DbSet<dbs.Raw_materials> Raw_materials { get; set; }
        public DbSet<dbs.Clients> Clients { get; set; }
        public DbSet<dbs.Stations> Stations { get; set; }
        public DbSet<dbs.Drivers> Drivers { get; set; }
        public DbSet<dbs.Checkers> Checkers { get; set; }
        public DbSet<dbs.Origins> Origins { get; set; }
        public DbSet<adm.Users> Users { get; set; }
        public DbSet<adm.Roles> Roles { get; set; }
        public DbSet<adm.Permissions> Permissions { get; set; }
        public DbSet<trns.Transactions> Transactions { get; set; }
        public DbSet<trns.Ref_no> Ref_nos { get; set; }
        public DbSet<trns.Tracker_time> Tracker_time { get; set; }
        public DbSet<trns.Trashed> Trashed{ get; set; }
        public DbSet<adm.Actions> Actions { get; set; }
        public DbSet<adm.logs> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<TRNS_TABLES.Transactions>()
            //        .HasOptional<DB_TABLES.Clients>(s => s.client)
            //         .WithMany(s => s.transactions) 
            //         .HasForeignKey(s => s.client_code);
        }

        protected override DbEntityValidationResult ValidateEntity(
        System.Data.Entity.Infrastructure.DbEntityEntry entityEntry,
        IDictionary<object, object> items)
        {
            this.ShouldValidateEntity(entityEntry);
            List<DbValidationError> errS;
            List<DbValidationError> err1 = new List<DbValidationError>();
            List<DbValidationError> err2 = new List<DbValidationError>();

            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());

            if (entityEntry.Entity is sys.domain.trns.Transactions) err1 = TransactionValidation.Validate(this, entityEntry);
            if (entityEntry.Entity is sys.domain.dbs.Clients) err1 = ClientsValidation.Validate(this, entityEntry);
            if (entityEntry.Entity is sys.domain.dbs.Raw_materials) err1 = MaterialsValidation.Validate(this, entityEntry);
            if (entityEntry.Entity is sys.domain.dbs.Origins) err1 = OriginsValidation.Validate(this, entityEntry);
            if (entityEntry.Entity is sys.domain.adm.Users) err1 = UsersValdation.Validate(this, entityEntry);
            if (entityEntry.Entity is sys.domain.trns.Ref_no) err1 = RefnoValidation.Validate(this, entityEntry);
   
            err2 = base.ValidateEntity(entityEntry, items).ValidationErrors.ToList();
            errS = err2.AsEnumerable().Union(err1.AsEnumerable()).ToList();
            result = new DbEntityValidationResult(entityEntry, errS);
            try
            {
                if (entityEntry.Entity is sys.domain.trns.Transactions) if (result.ValidationErrors.Count == 0) TransactionValidation.validationOK(this, entityEntry);
                if (entityEntry.Entity is sys.domain.adm.Users) if (result.ValidationErrors.Count == 0) UsersValdation.validationOK(this, entityEntry);
            }
            catch (Exception ex)
            {throw new Exception(ex.Message);}
            return result;
        }

        protected override bool ShouldValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Deleted)
            {
                return true;
            }
 	        
            return base.ShouldValidateEntity(entityEntry);
        }

        public sys.domain.adm.Users current_user { get; set; }
        
    }

}
