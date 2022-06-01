module.exports.db_all=function(db){
    return new Promise((reject,resolve)=>{
        db.all("select * from idojarasadatok",(error,rows)=>{
            if(error){
                reject("Error:"+error);
            }
            else {
                resolve(rows);
            }

        });
    });
}

module.exports.query_ev=function(db,ev){

    return new Promise((reject,resolve)=>{
        db.all("select * from idojarasadatok where ev=?",[ev],(error,rows)=>{
            if(error){
                reject("Error:"+error);
            }
            else {
                resolve(rows);
            }
    
        });

    });
    
};

module.exports.query_nap=function(db,ev,honap,nap){

    return new Promise((reject,resolve)=>{
        db.all("select * from idojarasadatok where ev=? and honap=? and nap=?",[ev,honap,nap],(error,rows)=>{
            if(error){
                reject("Error:"+error);
            }
            else {
                resolve(rows);
            }
    
        });

    });
    
};