namespace LantekCodingChallenge.Helpers
{
    public class Helper
    {
        public static string EncodeToBase64(string originalText)
        {
            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(originalText);
            string base64String = Convert.ToBase64String(utf8Bytes);
            return base64String;
        }
    }
}
