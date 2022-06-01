
import './App.css';
import Header from './components/Header';
import {BrowserRouter,NavLink,Switch,Route,Redirect} from 'react-router-dom';
import Karakterek from './components/Karakterek';
import Helyszinek from './components/Helyszinek';
import Epizodok from './components/Epizodok';

function App() {
  return (
    <div className="container-fluid bg-dark">
      <Header />
    <BrowserRouter>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid">
    <NavLink to={`/`} className="nav-link"  exact> 
      <span class="navbar-brand">Rick és Morty API</span>
    </NavLink>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
      <div class="navbar-nav">

        <NavLink to={`/karakterek`} className="nav-link">
        <span class="nav-link">Karakterek</span>
        </NavLink>
        <NavLink to={`/helyszinek`} className="nav-link">
        <span class="nav-link" href="#">Helyszínek</span>
        </NavLink>
        <NavLink to={`/epizodok`} className="nav-link">
        <span class="nav-link" href="#">Epizódok</span>
        </NavLink>
   
      </div>
    </div>
  </div>
</nav>
<Switch>
  <Route path="/" exact />
  <Route path="/karakterek"><Karakterek /></Route>
  <Route path="/helyszinek" component={Helyszinek} />
  <Route path="/epizodok"><Epizodok /></Route>
</Switch>
</BrowserRouter>
     
    </div>
  );
}

export default App;
