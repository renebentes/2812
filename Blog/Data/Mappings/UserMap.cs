using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(200);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(u => u.Bio)
            .IsRequired(false)
            .HasColumnType("TEXT");

        builder.Property(u => u.Image)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(2000);

        builder.Property(u => u.Slug)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.HasIndex(u => u.Slug, "IX_User_Slug")
            .IsUnique();

        builder.HasMany(it => it.Roles)
            .WithMany(it => it.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role.HasOne<Role>()
                            .WithMany()
                            .HasForeignKey("RoleId")
                            .HasConstraintName("FK_UserRole_RoleId")
                            .OnDelete(DeleteBehavior.Cascade),
                user => user.HasOne<User>()
                            .WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("FK_UserRole_UserId")
                            .OnDelete(DeleteBehavior.Cascade));
    }
}
