using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Entities
{
    public class PersonalSessionEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string SessionName { get; set; }
        public DateTime SessionDate { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }

        //relational prop
        public UserEntity User { get; set; }
        public CustomerEntity Customer { get; set; }
        
    }

    public class PersonalSessionConfiguration : BaseConfiguration<PersonalSessionEntity>
    {
        public override void Configure(EntityTypeBuilder<PersonalSessionEntity> builder)
        {
            builder.Property(x => x.SessionDate)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
