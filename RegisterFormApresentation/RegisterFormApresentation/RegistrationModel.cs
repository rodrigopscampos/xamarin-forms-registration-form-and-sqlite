using System;

namespace RegisterFormApresentation
{
    public class RegistrationModel
    {
        public string ID => Document;

        public string Document { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public DateTime Birthday { get; set; }
            = DateTime.Today.AddYears(-18);

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}