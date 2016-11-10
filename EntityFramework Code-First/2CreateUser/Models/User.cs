using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace _2CreateUser.Models
{
    public class User
    {
        private string email;

        public User()
        {
            IsDeleted = false;
        }


        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Username length between 4 and 30 symbols")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Password length should be between 6 and 50 symbols")]
        public string Password { get; set; }

        [Required]
        public string Email
        {
            get { return this.email; }
            set
            {
                string pattern = "@{1}";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Invalid e-mail adress");
                }

                this.email = value;
            }
        }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegistedOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(minimum: 1, maximum: 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public Town BornTown { get; set; }

        public Town CurrentlyLivingTown { get; set; }
    }
}
