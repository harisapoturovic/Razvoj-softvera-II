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

  Future<SearchResult<Product>> get({dynamic filter}) async{
    var url = "$_baseUrl$_enpoint";

     if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url?$queryString";
    }

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

  String getQueryString(Map params,
      {String prefix: '&', bool inRecursion: false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }
}