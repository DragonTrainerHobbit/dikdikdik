import Header from "./components/Header";
import Main from "./components/Main";
import Artists from "./components/Artists";
import {BrowserRouter,Switch,Route,Redirect} from "react-router-dom";

function App() {
  return (
    <div>
      <Header />
      <BrowserRouter>
      
      <Switch>
        <Route path='/' exact><Main /></Route>
        <Route path='/artists'><Artists /></Route>
        <Redirect to={'/'} />
      </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
