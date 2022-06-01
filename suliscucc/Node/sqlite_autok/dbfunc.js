module.exports.db_all=function(db){
    return new Promise((reject,resolve)=>{
        db.all("select * from autok",(error,rows)=>{
            if(error){
                reject("Error:"+error);
            }
            else {
                resolve(rows);
            }

        });
    });
}

module.exports.db_insert=function(db,{rendszam,marka,tipus,szin,gyartasiev}){
    return new Promise((reject,resolve)=>{
        db.run("insert into autok values(?,?,?,?,?)",[rendszam,marka,tipus,szin,gyartasiev],error=>{
            if(error){
                reject(error);
            } else {
                resolve({status:"Ok",message:"Adat beillesztve"});
            }
        });
    });

}

module.exports.db_update=function(db,{rendszam,marka,tipus,szin,gyartasiev}){
    return new Promise((reject,resolve)=>{
        db.run("update autok set marka=?,tipus=?,szin=?,gyartasiev=? where rendszam=?",[marka,tipus,szin,gyartasiev,rendszam],error=>{
            if(error){
                reject(error);
            } else {
                resolve({status:"Ok",message:"Adat módosítva"});
            }
        });
    });
}

module.exports.db_delete=function(db,{rendszam}){
    return new Promise((reject,resolve)=>{
        db.run("delete from autok where rendszam=?",[rendszam],error=>{
            if(error){
                reject(error);
            } else {
                resolve({status:"Ok",message:"Adat törölve"});
            }
          
        });
    })
    
}