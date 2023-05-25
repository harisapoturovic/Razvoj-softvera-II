import 'package:eprodaja_admin/models/search_result.dart';
import 'package:eprodaja_admin/providers/product_provider.dart';
import 'package:eprodaja_admin/screens/product_detail_screen.dart';
import 'package:eprodaja_admin/utils/util.dart';
import 'package:eprodaja_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:provider/provider.dart';

import '../models/product.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({super.key});

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  late ProductProvider _productProvider;
  SearchResult<Product>? result;
  TextEditingController _ftsController = new TextEditingController();
  TextEditingController _sifraController = new TextEditingController();

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _productProvider = context.read<ProductProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Container(
        child: Column(
          children: [
            _buildSearch(),
                _buildDataListView()
          ],
        ),
      ),
      title: "Product list",
    );
  }

  Widget _buildSearch()
  {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(children: [
        Expanded(
          child: TextField(
                      decoration: InputDecoration(
                          labelText: "Naziv ili šifra"),      
                          controller: _ftsController,             
                    ),
        ),
                      SizedBox(
                width: 8,
              ),
        Expanded(
          child: TextField(
                      decoration: InputDecoration(
                          labelText: "Šifra"),    
                          controller: _sifraController,               
                    ),
        ),
              SizedBox(
                width: 8,
              ),
              ElevatedButton(
                  onPressed: () async {
                    print("login proceed");
                    //Navigator.of(context).pop();
    
                    var data = await _productProvider.get(filter: { //dinamički objekat, umjesto da pravimo novu klasu kao što smo imali za proizvod
                      'fts': _ftsController.text,
                      'sifra': _sifraController.text
                    });
    
                    setState(() {
                      result = data;
                    });
    
                    //print("data: ${data.result[0].naziv}");
                  },
                  child: Text("Pretraga"))
      ]),
    );
  }

  Expanded _buildDataListView() {
    return Expanded(child: SingleChildScrollView(
                child: DataTable(columns: [
            const DataColumn(
              label: const Expanded(
                child: const Text(
                  "ID",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            const DataColumn(
              label: const Expanded(
                child: const Text(
                  "Sifra",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            const DataColumn(
              label: const Expanded(
                child: const Text(
                  "Naziv",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            const DataColumn(
              label: const Expanded(
                child: const Text(
                  "Cijena",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            const DataColumn(
              label: const Expanded(
                child: const Text(
                  "Slika",
                  style: const TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            )
              ],
              rows: 
                  result?.result.map((Product e) => 
                  DataRow(onSelectChanged: (selected) => {
                    if(selected == true) {
                        
                       Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => ProductDetailScreen(product: e),
                          ),
                        )
                    }
                  }, cells: [
                  DataCell(Text(e.proizvodId.toString() ?? "")),
                  DataCell(Text(e.sifra ?? "")),
                  DataCell(Text(e.naziv ?? "")),
                  DataCell(Text(formatNumber(e.cijena))),
                  DataCell(e.slika != ""
                            ? Container(
                                width: 100,
                                height: 100,
                                child: imageFromBase64String(e.slika!),
                              )
                            : Text(""))
              ])
                  ).toList()! ?? [],
              ),));
  }
}
