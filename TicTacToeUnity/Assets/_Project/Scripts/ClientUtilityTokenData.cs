namespace Tokenage
{
    //This class is used to struct information to post (erc20 contract)
    public class ClientUtilityTokenData
    {
        public string playerEmail;
        public string contract;
        public string value;

        public ClientUtilityTokenData(string _playerEmail, string _contract, string _value)
        {
            playerEmail = _playerEmail;
            contract = _contract;
            value = _value;
        }
    }
}
