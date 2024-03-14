import logo from './logo.png';

function Header() {
  return (
    <header className="row navbar navbar-dark bg-dark">
      <div className="col-4">
        <img src={logo} className="logo" alt="logo"></img>
      </div>
      <div className="col subtitle">
        <h1 className="text-white">We Still Be Bowlin'</h1>
      </div>
    </header>
  );
}

export default Header;
