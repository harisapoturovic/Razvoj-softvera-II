import 'package:json_annotation/json_annotation.dart';

part 'product.g.dart';

@JsonSerializable()
class Product
{
  int? proizvodId;
  String? naziv;
  String? sifra;
  double?cijena;
  String? slika;

  Product(this.proizvodId, this.naziv, this.sifra, this.cijena, this.slika);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Product.fromJson(Map<String, dynamic> json) => _$ProductFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ProductToJson(this);
}