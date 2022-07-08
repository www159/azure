﻿// See https://aka.ms/new-console-template for more information
using Flurl;
using Flurl.Http;
Console.WriteLine("Hello, World!");
var filter = "eventTimestamp ge '2022-07-01T08:02:12.6756260Z' and eventTimestamp le '2022-07-08T08:02:12.6756260Z' and resourceUri eq '/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/resourceGroups/W_GROUP/providers/Microsoft.Compute/virtualMachines/w'";
var apiVersion = "2015-04-01";
var url = "https://management.azure.com/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/providers/Microsoft.Insights/eventtypes/management/values";
var req = new Url(url)
    .SetQueryParam("$filter", filter)
    .SetQueryParam("api-version", apiVersion)
    .WithOAuthBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJaUXBKM1VwYmpBWVhZR2FYRUpsOGxWMFRPSSIsImtpZCI6IjJaUXBKM1VwYmpBWVhZR2FYRUpsOGxWMFRPSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzQ1M2Q4NjI4LTM0M2QtNDhiOS1iNGQ5LWMwYTk3ZTRiZTNiNy8iLCJpYXQiOjE2NTcyNjg4NzUsIm5iZiI6MTY1NzI2ODg3NSwiZXhwIjoxNjU3MjczNTQ1LCJhY3IiOiIxIiwiYWlvIjoiQVdRQW0vOFRBQUFBL0xFcFBTVENxVU1aRzBMNnpOM3FRc2llVlIwYVcxdStZZkF2NG53QUEwUlpIbEZ1OUpET1NkMzZlUVd2YzZFSWFlWVFQUHFSQTZhVVprQkhkWS9OTnoyVUN0UzlNWnNISlVkMkhrdEl0WC9QbVBKZWJpUEcwWk5xMEVIbTJhRC8iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDEwMkZERUZBMiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOGZiY2ExNi0yMjI0LTQ1ZjYtODViMC1mN2JmMmIzOWIzZjMiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6IjIxMDc3OTUyNDRAcXEuY29tIiwiZmFtaWx5X25hbWUiOiJwZXRlciIsImdpdmVuX25hbWUiOiJmdSIsImdyb3VwcyI6WyJjMmRiNzk0My1lNWZiLTQ2YzItYWMyZC0yY2Y0M2VkYTNiMzEiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiI1MC43LjI1Mi43NSIsIm5hbWUiOiJwZXRlciBmdSIsIm9pZCI6ImZhZDU5MTZlLTE2OTgtNDk2Yy1iZWU2LWI2MzE5MjQyNzc1YyIsInB1aWQiOiIxMDAzMjAwMjA3NDc5MzkxIiwicmgiOiIwLkFWVUFLSVk5UlQwMHVVaTAyY0NwZmt2anQwWklmM2tBdXRkUHVrUGF3ZmoyTUJPSUFOby4iLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiItdFdxSTlkOWRfUGZMUURORlB3eF9SOVFCM1dZazA3bkpvNk92THJTZnJRIiwidGlkIjoiNDUzZDg2MjgtMzQzZC00OGI5LWI0ZDktYzBhOTdlNGJlM2I3IiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSMyMTA3Nzk1MjQ0QHFxLmNvbSIsInV0aSI6InFBS2FiMWhqZDBHRFdybi1MMzF0QUEiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbIjYyZTkwMzk0LTY5ZjUtNDIzNy05MTkwLTAxMjE3NzE0NWUxMCIsImI3OWZiZjRkLTNlZjktNDY4OS04MTQzLTc2YjE5NGU4NTUwOSJdLCJ4bXNfdGNkdCI6MTY1NTcwMzQ2NX0.ZiXW444PBrWLUwX9oaS0yGW80lF1gh_6aBheUKhIFE9qNkN1fol1FFv_sjSDRCAjx0lp5-c5U-YG32b2XlV7mOVlgGk_8TlhmJa6IGJcK_1YLt1Aa2BfAK4kRRuqeVIJrBUx5fBSnCqqIMs6wc6umqo0xsKg0OzZn0A65f1yoeWVTxZd9ZZzOd34N3Wj4h-IZ5fYQy0vWLgklvlxP49flOPXGQ_R9Nfg752PIwA4WG7nCm32WKMP4p-0e-b5gU0HIrrAJLR9X5km6aw4zYzsRH7XHqdsB68nwFNnv_I1UdK7lDnSmiDv5gdg9QKOQeWe1ybHQFuK2JmfET73K8Wceg");

var req2 = new Url("https://management.azure.com/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/providers/Microsoft.Network/virtualNetworks")
    .SetQueryParam("api-version", "2021-08-01")
    .WithOAuthBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJaUXBKM1VwYmpBWVhZR2FYRUpsOGxWMFRPSSIsImtpZCI6IjJaUXBKM1VwYmpBWVhZR2FYRUpsOGxWMFRPSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzQ1M2Q4NjI4LTM0M2QtNDhiOS1iNGQ5LWMwYTk3ZTRiZTNiNy8iLCJpYXQiOjE2NTczMDc3MzcsIm5iZiI6MTY1NzMwNzczNywiZXhwIjoxNjU3MzExNzkyLCJhY3IiOiIxIiwiYWlvIjoiQVdRQW0vOFRBQUFBeEVmZUhQYW93S1RSYUVoNW9jSEhJcFRjTmNhMGt1c01Ud0tFNTZFdjFFL20wSHBZZmpGWStxUHdlMnlDWFI2c1FKakZkVnQrTW01UHpFU2NIaVBiRVNRWi9QejRwOE9zVFJDZDJ4VkgzT1JFUkg4NW1qNFhEdjJITEltSkc0M24iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDEwMkZERUZBMiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOGZiY2ExNi0yMjI0LTQ1ZjYtODViMC1mN2JmMmIzOWIzZjMiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6IjIxMDc3OTUyNDRAcXEuY29tIiwiZmFtaWx5X25hbWUiOiJwZXRlciIsImdpdmVuX25hbWUiOiJmdSIsImdyb3VwcyI6WyJjMmRiNzk0My1lNWZiLTQ2YzItYWMyZC0yY2Y0M2VkYTNiMzEiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiI1MC43LjI1Mi43OCIsIm5hbWUiOiJwZXRlciBmdSIsIm9pZCI6ImZhZDU5MTZlLTE2OTgtNDk2Yy1iZWU2LWI2MzE5MjQyNzc1YyIsInB1aWQiOiIxMDAzMjAwMjA3NDc5MzkxIiwicmgiOiIwLkFWVUFLSVk5UlQwMHVVaTAyY0NwZmt2anQwWklmM2tBdXRkUHVrUGF3ZmoyTUJPSUFOby4iLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiItdFdxSTlkOWRfUGZMUURORlB3eF9SOVFCM1dZazA3bkpvNk92THJTZnJRIiwidGlkIjoiNDUzZDg2MjgtMzQzZC00OGI5LWI0ZDktYzBhOTdlNGJlM2I3IiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSMyMTA3Nzk1MjQ0QHFxLmNvbSIsInV0aSI6IjJHQlRkbVFrT1VpcXZ6YXJWNjUyQUEiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbIjYyZTkwMzk0LTY5ZjUtNDIzNy05MTkwLTAxMjE3NzE0NWUxMCIsImI3OWZiZjRkLTNlZjktNDY4OS04MTQzLTc2YjE5NGU4NTUwOSJdLCJ4bXNfdGNkdCI6MTY1NTcwMzQ2NX0.iImUM09lOI2-iMWXrAMylEN7_XAirQvhIltRSHqKC2_YRfYiWwC9clZK48ikxZNsrNmSINpgh-jHhtVd-s19rhiHXUFgksYi278KH8poSvHaCFXQ1F5Jc3HNlepZ8NgORq5uk-zKeZ5OU-kvLDofBbvfpp3XMII1A4wRxY-bQFQL24lDs9sC6Y6HEj9pkP9oagWvH--wRrpUxdSNjy6XsWqZ5kBfqHDg2cXw8J0GfYvIbmRJxAH_rV-muUZoWTuIEntW-BuueXSJr7iNSFG6_x8mFnWZo31xT5KZqWi7XZn6rP3Np8DoQEVgLuOSjrLgnAaDpsJ_s44jTAz25eQI_w");
var str = await req2.GetStringAsync();

Console.WriteLine(str);