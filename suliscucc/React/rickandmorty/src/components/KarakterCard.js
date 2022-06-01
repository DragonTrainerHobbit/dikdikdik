
function KarakterCard(props){
    return (
        <div class="card mb-3" style={{"max-width": 540}}>
        <div class="row g-0">
          <div class="col-md-4">
            <img src={props.character.image} class="img-fluid rounded-start" />
          </div>
          <div class="col-md-8">
            <div class="card-body">
              <h5 class="card-title">{props.character.name}</h5>
              <p class="card-text">{props.character.gender}</p>
              <p class="card-text">{props.character.species}</p>
              <p class="card-text">{props.character.status}</p>
              <p class="card-text"><small class="text-muted">Created:{props.character.created}</small></p>
            </div>
          </div>
        </div>
      </div>
    );

}

export default KarakterCard;