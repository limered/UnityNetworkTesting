using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

#pragma warning disable 618

namespace Networking
{
    public class ManagerOfNetworks : NetworkManager
    {
        public void ServerStart()
        {
            matchMaker.CreateMatch("match", 10, true, string.Empty, string.Empty, string.Empty, 0, 0,
                MatchMaker_OnCreateMatch);
        }

        public void ClientStart()
        {
            matchMaker.ListMatches(0, 10, string.Empty, false, 0, 0, MatchMaker_OnListMatches);
        }

        private void MatchMaker_OnCreateMatch(bool success, string extendedInfo, MatchInfo responseData)
        {
            OnMatchCreate(success, extendedInfo, responseData);
        }
        private void MatchMaker_OnListMatches(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
        {
            var firstMatch = responseData.First();

            matchMaker.JoinMatch(firstMatch.networkId, string.Empty, string.Empty, string.Empty, 0, 0,
                MatchMaker_OnJoinMatch);
        }

        private void MatchMaker_OnJoinMatch(bool success, string extendedInfo, MatchInfo responseData)
        {
            OnMatchJoined(success, extendedInfo, responseData);
        }

        private void Start()
        {
            StartMatchMaker();
        }
    }
}