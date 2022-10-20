namespace MovieReview.Database.Services.Interfaces
{
    internal interface ICryptographyService
    {
        string Encrypt(string textToEncrypt);
        string Decrypt(string textToDecrypt);
        void SetOperation();
        void SetBeginCryptography();
    }
}
