import 'package:eprodaja_admin/main.dart';
import 'package:eprodaja_admin/screens/product_detail_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../screens/product_list_screen.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? title;
  MasterScreenWidget({this.child, this.title, super.key});

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title ?? ""),
      ),
      body: widget.child!,
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              title: Text("Back"),
              onTap: (){
                Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => LoginPage()));
              } ,

            ),
            ListTile(
              title: Text("Products"),
              onTap: (){
                Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => ProductListScreen()));
              } ,

            ),
            ListTile(
              title: Text("Details"),
              onTap: (){
                Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => ProductDetailScreen()));
              } ,

            )
          ],
        ),
      ),
    );
  }
}