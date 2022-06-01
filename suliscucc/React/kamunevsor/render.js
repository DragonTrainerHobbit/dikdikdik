let root=document.getElementById('root')

root.setAttribute('style','display:flex;flex-wrap:wrap')


/*for(i=0;i<adatok.length;i++){
    let emberDiv=document.createElement('div')
    emberDiv.setAttribute('style','margin:10px;padding:10px;background-color:aqua')
    let emberNev=document.createElement('p')
    let emberLista=document.createElement('ul')
    let emberLakhely=document.createElement('li')
    let emberEletkor=document.createElement('li')
    let emberKep=document.createElement('img')

    emberNev.textContent=adatok[i].nev
    emberLakhely.textContent=adatok[i].lakhely
    emberEletkor.textContent=adatok[i].eletkor
    emberKep.src=adatok[i].foto
    emberKep.width=100

    emberLista.appendChild(emberLakhely)
    emberLista.appendChild(emberEletkor)

    emberDiv.appendChild(emberNev)
    emberDiv.appendChild(emberLista)
    emberDiv.appendChild(emberKep)

    root.appendChild(emberDiv)

}*/

for(i=0;i<adatok.length;i++){

    let cardDiv=document.createElement('div')
    cardDiv.setAttribute('class','card')
    cardDiv.setAttribute('style','width: 18rem; margin:10px')

    let cardImg=document.createElement('img')
    cardImg.setAttribute('class','card-img-top')
    cardImg.src=adatok[i].foto
    cardDiv.appendChild(cardImg)
    
    let cardBody=document.createElement('div')
    cardBody.setAttribute('class','card-body')

    let cardTitle=document.createElement('h5')
    cardTitle.setAttribute('class','card-title')
    cardTitle.textContent=adatok[i].nev
    cardBody.appendChild(cardTitle)

    let cardText=document.createElement('p')
    cardText.setAttribute('class','card-text')
    cardText.textContent=adatok[i].lakhely+","+adatok[i].eletkor
    cardBody.appendChild(cardText)

    let cardButton=document.createElement('a')
    cardButton.setAttribute('class','btn btn-primary')
    cardButton.textContent="Tovább"
    cardBody.appendChild(cardButton)

    cardDiv.appendChild(cardBody)


    root.appendChild(cardDiv)


}

