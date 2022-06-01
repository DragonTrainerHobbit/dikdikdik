module.exports.mindenAdat=function(db){
    return new Promise((reject,resolve)=>{
        db.all("select * from idojarasadatok",(error,rows)=>{
            if(error){
                reject(error);
            } else {
                resolve(rows);
            }
        });
    });
}

module.exports.getEv=function(db,ev){
    return new Promise((reject,resolve)=>{
        db.all(
            "select * from idojarasadatok where ev=?",
            [ev],
            (error,rows)=>{
                if(error){
                    reject(error);
                } else {
                    resolve(rows);
                }

            });

    });
}

module.exports.getNap=function(db,ev,honap,nap){
    return new Promise((reject,resolve)=>{
        db.all(
            "select * from idojarasadatok where ev=? and honap=? and nap=?",
            [ev,honap,nap],
            (error,rows)=>{
                if(error) {
                    reject(error);
                } else {
                    resolve(rows);
                }

            }
            );

    });
}

module.exports.insertNap=function(db,props){
    return new Promise((reject,resolve)=>{
        db.run("insert into idojarasadatok values(?,?,?,?,?,?,?)",
        [
        props.ev,
        props.honap,
        props.nap,
        props.ora,
        props.homerseklet,
        props.szelsebesseg,
        props.paratartalom
        ],
        error=>{
            if(error){
                reject(error);
            } else {
                resolve({status:'Ok',message:'Adat beszúrva!'});
            }
        }
        );
    });

}