using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TrialExternalLogin.Models;

namespace TrialExternalLogin.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<User>()
		.Property(e => e.FirstName)
		.HasMaxLength(200);

		builder.Entity<User>()
		.Property(e => e.LastName)
		.HasMaxLength(200);

		builder.Entity<User>()
		.Property(e => e.EmployeeId)
		.HasMaxLength(10);
	}
}