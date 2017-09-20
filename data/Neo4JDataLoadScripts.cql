https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/books.json
https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/houses.json
https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json

CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/books.json") 
YIELD value 
MERGE (book:Book {id: value.Id}) ON CREATE SET book.id = value.Id, book.name = value.Name, book.ISBN = value.ISBN, book.pages = value.NumberOfPages, book.releaseDate = value.ReleaseDate, book.country = value.Country, book.publisher = value.Publisher, book.authors = value.Authors

CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
MERGE (culture:Culture {name: value.Culture}) ON CREATE SET culture.name = value.Culture

CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value
UNWIND value.TvSeries AS tvSeries
MERGE (series:TvSeries {name: tvSeries}) ON CREATE SET series.name = tvSeries


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value
MERGE (character:Character {id: value.Id}) ON CREATE SET character.id = value.Id, character.name = value.Name, character.aliases = value.Aliases, character.titles = value.Titles, character.born = value.Born, character.died = value.Died, character.playedBy = value.PlayedBy


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
MATCH (character:Character {id: value.Id}), (culture:Culture {name: value.Culture})
CREATE (character)-[:MEMBEROF]->(culture)


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
UNWIND value.Books AS bookid
MATCH (character:Character {id: value.Id}), (book:Book {id: bookid})
CREATE (character)-[:APPEARS]->(book)


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
MATCH (character:Character {id: value.Id}), (father:Character {id: value.Father})
CREATE (character)-[:FATHER]->(father)


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
MATCH (character:Character {id: value.Id}), (mother:Character {id: value.Mother})
CREATE (character)-[:MOTHER]->(mother)


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
MATCH (character:Character {id: value.Id}), (spouse:Character {id: value.Spouse})
CREATE (character)-[:SPOUSE]->(spouse)


CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value 
UNWIND value.Children AS childId
MATCH (character:Character {id: value.Id}), (children:Character {id: childId})
CREATE (character)-[:CHILD]->(children)

CALL apoc.load.jsonArray("https://raw.githubusercontent.com/johncrocker/AnApiOfIceAndFire/master/data/characters.json") 
YIELD value
UNWIND value.TvSeries AS tvSeries
MATCH (character:Character {id: value.Id}), (series:TvSeries {name: tvSeries})
CREATE (character)-[:APPEAREDIN]->(series)
