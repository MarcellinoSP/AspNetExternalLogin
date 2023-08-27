using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TrialExternalLogin.Models;

public class User : IdentityUser
{
	[Required]
	public string EmployeeId {get; set;}
	[Required]
	public string FirstName {get; set;}
	[Required]
	public string LastName {get; set;}
}
