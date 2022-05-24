using System.Collections.Generic;

namespace Tokenage
{
    //This class is used to store multiple information from the user, and to exchange information between collections and the API.
    public class NFTManager
    {
        static NFTManager instance;
        public UserNFTGameData userNFT
        {
            private set;
            get;
        }
        public UserNotMintedData userRewards
        {
            private set;
            get;
        }

        public delegate void UpdateNFTs();
        public UpdateNFTs updateNFTs;
        private bool hasNFTUpdated;
        private bool hasRewardsUpdated;

        public static NFTManager GetInstance()
        {
            if (instance == null)
                instance = new NFTManager();
            return instance;
        }

        public void SetNFT(string data)
        {
            string newData = UnwrapJson(data);
            var root = JSON.Parse(newData);

            string newContracts = UnwrapJson(root["erc721Contracts"].ToString());
            string[] contractArray = ReturnArrayJson(newContracts);
            ContractData[] contractsData = new ContractData[contractArray.Length];

            for (int i = 0; i < contractArray.Length; i++)
            {
                var contract = JSON.Parse(contractArray[i]);
                contractsData[i] = new ContractData(
                    contract["symbol"],
                    contract["friendlyName"],
                    contract["name"],
                    contract["adress"],
                    null,
                    contract["image"],
                    contract["id"],
                    contract["category"],
                    contract["attributes"],
                    contract["tokenId"],
                    contract["owner"],
                    contract["ownerName"],
                    contract["contract"],
                    contract["contractName"],
                    contract["contractFriendlyName"],
                    contract["gameId"],
                    contract["gameName"],
                    contract["commission"],
                    contract["providerId"],
                    contract["providerName"],
                    contract["minted"]
                    );
            }
            userNFT = new UserNFTGameData(root["name"],
                root["comission"], 
                root["provider"],
                contractsData
                );

            hasNFTUpdated = true;
            CheckIfBothObjectsWereUpdated();
        }

        private string UnwrapJson(string json)
        {
            string newJson = string.Empty;

            for (int i = 0; i < json.Length; i++)
            {
                if (i == 0 || i == json.Length - 1) continue;
                newJson += json[i];
            }

            return newJson;
        }

        private string[] ReturnArrayJson(string json)
        {
            List<string> localList = new List<string>();
            bool isListening = false;
            int layer = 0;

            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == '{')
                {
                    if (!isListening)
                    {
                        isListening = true;
                        localList.Add(string.Empty);
                    }
                    else layer++;
                }
                else if (json[i] == '}')
                {
                    if (isListening)
                    {
                        if (layer > 0) layer--;
                        else isListening = false;
                    }
                }
                if (isListening)
                {
                    localList[localList.Count - 1] += json[i];
                }
            }

            return localList.ToArray();
        }

        public void SetRewards(string data)
        {
            string newData = UnwrapJson(data);
            var root = JSON.Parse(newData);

            string new721Contracts = UnwrapJson(root["erc721Contracts"].ToString());
            string[] contractArray721 = ReturnArrayJson(new721Contracts);
            Erc721ContractsData[] erc721 = new Erc721ContractsData[contractArray721.Length];
            string new20Contracts = UnwrapJson(root["erc20Contracts"].ToString());
            string[] contractArray20 = ReturnArrayJson(new20Contracts);
            Erc20ContractsData[] erc20 = new Erc20ContractsData[contractArray20.Length];

            for (int i = 0; i < contractArray721.Length; i++)
            {
                var contract = JSON.Parse(contractArray721[i]);

                string newTokenRewards = UnwrapJson(contract["nfts"].ToString());
                string[] tokenArray = ReturnArrayJson(newTokenRewards);
                TokenRewardData[] tokenRewards = new TokenRewardData[tokenArray.Length];

                for (int r = 0; r < tokenArray.Length; r++)
                {
                    var token = JSON.Parse(tokenArray[r]);

                    tokenRewards[r] = new TokenRewardData(token["name"], 
                        token["description"], 
                        token["image"],
                        token["id"],
                        token["tokenId"],
                        token["owner"],
                        token["ownerName"],
                        token["contract"],
                        token["contractName"],
                        token["contractFriendlyName"],
                        token["gameId"],
                        token["gameName"],
                        token["comission"],
                        token["providerId"],
                        token["providerName"],
                        token["minted"]
                        );
                }

                erc721[i] = new Erc721ContractsData(contract["symbol"],
                    contract["friendlyName"],
                    contract["name"],
                    contract["address"],
                    tokenRewards
                    );
            }

            for (int i = 0; i < contractArray20.Length; i++)
            {
                var contract = JSON.Parse(contractArray20[i]);

                string newToken = UnwrapJson(contract["token"].ToString());
                string[] tokenArray = ReturnArrayJson(newToken);
                Erc20Token[] tokenData = new Erc20Token[tokenArray.Length];

                for (int r = 0; r < tokenArray.Length; r++)
                {
                    var token = JSON.Parse(tokenArray[r]);

                    tokenData[r] = new Erc20Token(token["contractId"],
                        token["userId"],
                        token["value"],
                        token["sequence"],
                        token["canClaim"],
                        token["pendingValue"],
                        token["pendingSequence"]
                        );
                }

                erc20[i] = new Erc20ContractsData(contract["symbol"],
                    contract["friendlyName"],
                    contract["name"],
                    contract["address"],
                    tokenData
                    );
            }

            userRewards = new UserNotMintedData(root["name"],
                root["commision"], 
                root["provider"],
                erc721,
                erc20
                );

            hasRewardsUpdated = true;
            CheckIfBothObjectsWereUpdated();
        }

        private void CheckIfBothObjectsWereUpdated()
        {
            if (hasNFTUpdated && hasRewardsUpdated)
            {
                hasNFTUpdated = false;
                hasRewardsUpdated = false;
                updateNFTs();
            }
        }

        public List<List<CollectionItem>> ReturnOnlineCollectionItensByLocalCollections(List<Collection> collections)
        {
            List<List<CollectionItem>> value = new List<List<CollectionItem>>();

            for (int i = 0; i < collections.Count; i++)
            {
                value.Add(new List<CollectionItem>());
                for (int j = 0; j < userRewards.erc721Contracts.Length; j++)
                {
                    if (userRewards.erc721Contracts[j].address == collections[i].Contract)
                    {
                        for (int r = 0; r < collections[i].Items.Count; r++)
                        {
                            for (int k = 0; k < userRewards.erc721Contracts[j].nft.Length; k++)
                            {
                                if (userRewards.erc721Contracts[j].nft[k].id == collections[i].Items[r].Id)
                                {
                                    if (value[i].Contains(collections[i].Items[r])) continue;
                                    value[i].Add(collections[i].Items[r]);
                                }
                            }
                        }
                    }
                }
            }
            return value;
        }
    }
}
