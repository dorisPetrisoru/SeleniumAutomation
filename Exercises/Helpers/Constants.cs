using System.Collections.Generic;

namespace Exercises.Helpers
{
    public class Constants
    {
        public static readonly string STRINGPHRASE = "tESTaUTOMATION";
        public static readonly string USERNAME = "doris.petrisoru@yahoo.com";
        public static readonly string ENCODED_PASS = "YhRBMTukHZI8xTL4be7sD3yD98ulI+ZbwvlMowH7UEGFTpCt9ibMJ2DbUJWQlgtRRIlwzEjGUGwl4tg5KROdsJFecfuF/k/d8I7G/JXj3tAJcCsNIp9Wp1rIRC0mdbjf";

        public static readonly List<string> EXPECTED_LOGGED_IN_MENUS = new List<string>
            {
                "My IBM", "Profile", "Billing" ,"Sign out"
            };

        public static readonly List<string> EXPECTED_LOGGED_OUT_MENUS = new List<string>
            {
                "My IBM", "Log in"
            };
    }
}
