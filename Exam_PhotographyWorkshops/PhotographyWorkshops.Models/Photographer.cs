using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Photographer
    {
        //•	First Name – mandatory information
        //•	Last Name – text that can contain between 2 and 50 characters, mandatory information
        //•	Phone – must be in the format “+[country_code]/[phone]” where[country_code] is between 1 and 3 digits and the[phone] is between 8 and 10 digits.
        //o Valid phones: +359/88888888, +1/1234579284
        //o Invalid phones: -359/88888888, +359/      4    5 4444444, +359888585313, +412\34553363587
        //•	Primary Camera – can be any camera(DSLR or Mirrorless). Mandatory information
        //•	Secondary Camera – can be any camera(DSLR or Mirrorless). Mandatory information
        //•	Many Lenses
        //•	Many Accessories

        private ICollection<Len> lenses;
        private ICollection<Accessory> accessories;
        private ICollection<Workshop> workshopdParticipatedIn;
        private ICollection<Workshop> workshopdTrainedIn;

        public Photographer()
        {
            this.lenses = new HashSet<Len>();
            this.accessories = new HashSet<Accessory>();
            this.workshopdParticipatedIn = new HashSet<Workshop>();
            this.workshopdTrainedIn = new HashSet<Workshop>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [Range(2, 50)]
        public string LastName { get; set; }

        [PhoneValidation]
        public string Phone { get; set; }

        public int PrimaryCameraId { get; set; }

        public int SecondaryCameraId { get; set; }

      //  [Required]
        [ForeignKey("PrimaryCameraId")]
     //   [InverseProperty("PrimaryOwners")]
        public virtual Camera PrimaryCamera { get; set; }

      //  [Required]
       // [InverseProperty("SecondaryOwners")]
        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Len> Lenses
        {
            get { return this.lenses; }
            set { this.lenses = value; }
        }

        public virtual ICollection<Accessory> Accessories
        {
            get { return this.accessories; }
            set { this.accessories = value; }
        }

        public virtual ICollection<Workshop> WorkshopsParticipatedIn
        {
            get { return this.workshopdParticipatedIn; }
            set { this.workshopdParticipatedIn = value; }
        }

        public virtual ICollection<Workshop> WorkshopsTrainedIn
        {
            get { return this.workshopdTrainedIn; }
            set { this.workshopdTrainedIn = value; }
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class PhoneValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringFieldValue = value as string;

            if (!stringFieldValue.StartsWith("+"))
            {
                return false;
            }

            string partWithoutPlus = stringFieldValue.Substring(1, stringFieldValue.Length - 1);
            string regexPattern = @"[0-9]{1,3}\/[0-9]{8,10}";
            Regex regex = new Regex(regexPattern);

            if (!regex.IsMatch(stringFieldValue))
            {
                return false;
            }

            return true;
        }

    }
}
