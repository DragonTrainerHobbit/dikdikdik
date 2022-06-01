let request=new XMLHttpRequest()

request.open('GET','https://randomuser.me/api/?results=50',true)

request.onload=function(){

    var data=JSON.parse(this.response)

    if(request.status>=200 && request.status<=400){
         //itt kell kezdeni valamit a kapott adatokkal
         console.log(data)   
         data.results.forEach(e => {
             document.writeln(e.name.title+"."+e.name.first+" "+e.name.last+"<BR>")
         });


    } else {
        console.log('Hiba')
    }

}

request.send()






