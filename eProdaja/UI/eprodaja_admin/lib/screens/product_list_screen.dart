import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({super.key});

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [
          Text("TEST"),
          SizedBox(height: 8,),
                  ElevatedButton(onPressed: (){
                    print("login proceed");
                    Navigator.of(context).pop();
                  }, child: Text("Back"))
        ],
      )
    );
  }
}