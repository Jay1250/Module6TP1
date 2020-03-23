using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BO
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
    }
}
