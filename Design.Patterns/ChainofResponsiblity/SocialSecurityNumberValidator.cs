using System.Globalization;

namespace Design.Patterns.ChainofResponsiblity
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo region)
        {
            //C# 8.0 version
            return region.TwoLetterISORegionName switch
            {
                "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
                "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
                _ => throw new UnsupportedSocialSecurityNumberException()
            };
        }

        private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 1;
        }
        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 2;
        }
    }
}
