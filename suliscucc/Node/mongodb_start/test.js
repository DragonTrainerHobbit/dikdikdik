const {MongoClient}=require('mongodb');

async function dbLista(client){
    const dblist=await client.db().admin().listDatabases();
    console.log("Adatbázisok:");
    console.log(dblist.databases.forEach(db=>console.log(db.name)));

}



async function ujAuto(client,auto){
    const eredmeny=await client
    .db("autodb")
    .collection("autok")
    .insertOne(auto);

    console.log(`Beszúrva:${eredmeny.insertedId}`);
}


async function updateAuto(client,gyartmany,updateData){
    const eredmeny=await client
    .db("autodb")
    .collection("autok")
    .updateOne({'gyartmany':gyartmany},{$set:updateData});
    console.log(eredmeny.matchedCount);
    console.log(eredmeny.modifiedCount);

}

async function deleteAuto(client,rendszam){
    const eredmeny=await client
    .db("autodb")
    .collection("autok")
    .deleteOne({'_id':rendszam});
    console.log(eredmeny.deletedCount);
}

async function dbGetRendszam(client,rendszam){

    const eredmeny=await client
    .db("autodb")
    .collection("autok")
    .findOne({"_id":rendszam});

    if(eredmeny){
        console.log(eredmeny);
    } else {
        console.log("Nincs ilyen rendszámú autó!");
    }


}


async function dbtest(){
    const url='mongodb://localhost:27017';
    const client=new MongoClient(url);

    try{
        await client.connect();
        //adatbázis műveletek
        await dbLista(client);
        await dbGetRendszam(client,"ZHG-119");
        /*const auto={
            _id:"VGD-622",
            gyartmany:"Skoda",
            tipus:"Superb",
            gyartasiev:"2011"
        }*/
        //await ujAuto(client,auto);
        await updateAuto(client,"Volkswagen",{tipus:'Bora'});
        await deleteAuto(client,"VGD-622");
       

    }catch(e)
    {
          console.error(e);

    } finally{
        await client.close();
    }

}

dbtest().catch(console.error);