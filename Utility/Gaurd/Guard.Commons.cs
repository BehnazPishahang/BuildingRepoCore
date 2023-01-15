using Utility.Gaurd;

namespace Utility.Gaurd
{
    public static class Commons
    {
        public static T Null<T>(this T input, Enum type, string args = null)
        {
            if (input is null)
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static bool Null<T>(this T input)
        {
            if (input is null)
            {
                return true;
            }
            if (input is System.Collections.ICollection)
            {
                if (((System.Collections.ICollection)input).Count == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static string NullOrEmpty(this string? input, Enum type, string args = null)
        {
            input.Null(type, args);
            if (input == string.Empty)
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static bool NullOrEmpty(this string? input)
        {
            if (input.Null())
            {
                return true;
            }

            if (input == string.Empty)
            {
                return true;
            }

            return false;
        }

        public static Guid NullOrEmpty(this Guid? input, Enum type, string args = null)
        {
            input.Null(type);
            if (input == Guid.Empty)
            {
                throw new AnuExceptions(type, args);
            }

            return input.Value;
        }

        public static IEnumerable<T> NullOrEmpty<T>(this IEnumerable<T>? input, Enum type, string args = null)
        {
            input.Null(type);
            if (!input.Any())
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static string NullOrWhiteSpace(this string? input, Enum type, string args = null)
        {
            input.NullOrEmpty(type, args);
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static bool NullOrWhiteSpace(this string? input)
        {
            if (input.NullOrEmpty())
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            return false;
        }

        public static T Default<T>(this T input, Enum type, string args = null)
        {
            if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static string IsDigit(this string value, Enum type, int length = 0, string args = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new AnuExceptions(type, args);
            }
            if (length != 0 && value.Length != length)
            {
                throw new AnuExceptions(type, args);
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    throw new AnuExceptions(type, args);
                }
            }
            return value;
        }

        public static string Length(this string? input, Enum type, int length, string args = null)
        {
            if (input.Length != length)
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        public static string IsMatch(this string? input, Enum type, Regex regex, string args = null)
        {
            if (!regex.IsMatch(input))
            {
                throw new AnuExceptions(type, args);
            }

            return input;
        }

        ////todo: it should be reviewed by s.kavianimehr 
        //public static string IsValidNationalCode(this string nationalCode)
        //{
        //    //در صورتی که کد ملی وارد شده تهی باشد
        //    nationalCode.NullOrEmpty(AnuResult.NationalCode_Is_Not_Valid);

        //    //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
        //    nationalCode.Length(AnuResult.NationalCode_Length_Is_Not_Valid, 10);

        //    //در صورتی که کد ملی ده رقم عددی نباشد
        //    var regex = new Regex(@"\d{10}");
        //    nationalCode.IsMatch(AnuResult.NationalCode_Must_Be_Number, regex);

        //    //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
        //    var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
        //    if (allDigitEqual.Contains(nationalCode))
        //    {
        //        nationalCode.NullOrEmpty(AnuResult.NationalCode_Is_Not_Valid);
        //    }

        //    return nationalCode;
        //}

        //todo it should be reviewed by s.kavianimehr 
        public static bool IsValidDate(this string? dateString, Enum type, string args = null)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                throw new AnuExceptions(type, args);
            }

            bool blnTruncated = true;
            bool blnValid = true;

            dateString = dateString.Trim();

            if (dateString.Length == 10)
                blnTruncated = false;
            else if (dateString.Length == 8)
                blnTruncated = true;
            else
            {
                blnValid = false;
                throw new AnuExceptions(type, args);
            }

            if (blnValid)
            {
                int pos1 = dateString.IndexOf("/");

                if (pos1 == 4 && !blnTruncated || pos1 == 2 && blnTruncated)
                {
                    int pos2 = dateString.IndexOf("/", pos1 + 1);
                    if (pos2 == 7 && !blnTruncated || pos1 == 5 && blnTruncated)
                    {
                        string[] arrDateItems = dateString.Split('/');

                        int year = int.Parse(arrDateItems[0]);
                        int month = int.Parse(arrDateItems[1]);
                        int day = int.Parse(arrDateItems[2]);

                        if (blnTruncated)
                            year += 1300;

                        if (month <= 12 && month >= 1)
                        {
                            if (month < 7)
                                blnValid = day <= 31 && day >= 1;
                            else if (month < 12 && month >= 7 || month == 12 && IsLeapYear(year))
                                blnValid = day <= 30 && day >= 1;
                            else
                                blnValid = day <= 29 && day >= 1;

                        }
                        else
                        {
                            blnValid = false;
                            throw new AnuExceptions(type, args);
                        }

                    }
                    else
                    {
                        blnValid = false;
                        throw new AnuExceptions(type, args);
                    }
                }
                else
                {
                    blnValid = false;
                    throw new AnuExceptions(type, args);
                }
            }

            return blnValid;

        }

        public static bool IsValidPhone(this string? dateString)
        {
            return true;
        }

        public static bool IsLeapYear(int year)
        {
            int temp1, temp2;

            if (year == 474)
                return true;

            if (year < 474)
                temp1 = year + 42;
            else
                temp1 = year + 38;

            temp2 = temp1 % 128;
            if (temp2 == 0)
                return true;

            if (temp2 <= 30)//main
            {
                if (temp2 % 4 == 1 && temp2 != 1)
                    return true;
            }
            else
            {
                if (temp2 <= 63) //2
                {
                    if (temp2 % 4 == 2)
                        return true;
                }
                else
                {
                    if (temp2 <= 96) //3
                    {
                        if (temp2 % 4 == 3)
                            return true;
                    }
                    else
                    {
                        if (temp2 > 30)
                        {
                            if (temp2 % 4 == 0) return true;
                        }
                    }//else 3
                }//else 2
            }//if else main

            return false;
        }

        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        public class PasswordAdvisor
        {
            public static PasswordScore CheckStrength(string password)
            {
                int score = 0;

                if (password.Length < 1)
                    return PasswordScore.Blank;
                if (password.Length < 4)
                    return PasswordScore.VeryWeak;

                if (password.Length >= 8)
                    score++;
                if (password.Length >= 12)
                    score++;
                if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
                  Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                    score++;

                return (PasswordScore)score;
            }
        }
    }
}