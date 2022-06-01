
function Artist({artist}) {
  return (
    <div class="card w-96 bg-base-100 shadow-xl my-2 justify-self-center">
                <figure></figure>
                <div class="card-body">
                  <h2 class="card-title">
                    {artist.Name}
                    <div class="badge badge-secondary">NEW</div>
                  </h2>
                  <p>Zenészek listás</p>
                  <div class="card-actions justify-end">
                    <div class="badge badge-outline">rock,metal</div> 
                    <div class="badge badge-outline">pop,jazz</div>
                  </div>
                </div>
              </div>
  )
}

export default Artist;