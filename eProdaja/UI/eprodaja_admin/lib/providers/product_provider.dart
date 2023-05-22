import 'dart:convert';

import 'package:eprodaja_admin/models/product.dart';
import 'package:eprodaja_admin/models/search_result.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

import '../utils/util.dart';

class ProductProvider with ChangeNotifier
{
  static String? _baseUrl;
  String _enpoint="Proizvodi";

  ProductProvider()
  {
    _baseUrl= const String.fromEnvironment("baseUrl", defaultValue: "https://localhost:7114/api/");
  }

  Future<SearchResult<Product>> get() async{
    var url = "$_baseUrl$_enpoint";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);
    //print("response:${response.request}, ${response.statusCode}, ${response.body}");

    if(isValidResponse(response))
    {
      var data = jsonDecode(response.body);

      var result = SearchResult<Product>();

      result.count = data["count"];

      for(var item in data["result"]) // =foreach
      {
          result.result.add(Product.fromJson(item));
      }

      return result;
    }else{
      throw new Exception("Unknown error");
    }
  }
  
    bool isValidResponse(Response response)
    {
        if(response.statusCode<299){
          return true;
        }else if(response.statusCode==401){
          throw new Exception("Unauthorized");
        }else{
          throw new Exception("Someting bad happened please try again");
        }

    }

  Map<String, String> createHeaders(){
    String username = Authorization.username ?? " ";
    String password=Authorization.password ?? " ";

    print("passed creds: $username $password");

    String basicAuth = "Basic ${base64Encode(utf8.encode("$username:$password"))}";

    var headers={
      "Content-Type":"application/json",
      "Authorization":basicAuth
    };

    return headers;
  }
}