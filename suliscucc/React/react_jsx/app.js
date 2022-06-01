var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

function App() {
    var szam = 10;
    var szamok = [10, 233, 567, 55, 77, 219, 345, 1154, 889, 1123, 556];

    var _React$useState = React.useState(0),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        ertek = _React$useState2[0],
        setErtek = _React$useState2[1];

    var _React$useState3 = React.useState(true),
        _React$useState4 = _slicedToArray(_React$useState3, 2),
        lathato = _React$useState4[0],
        setLathato = _React$useState4[1];

    return React.createElement(
        'div',
        null,
        React.createElement(
            'h1',
            null,
            'Jsx szintaxis'
        ),
        React.createElement(
            'h2',
            null,
            'Sz\xE1m:',
            ertek
        ),
        lathato ? React.createElement(
            'ul',
            null,
            szamok.map(function (szam) {
                return React.createElement(
                    'li',
                    null,
                    szam
                );
            })
        ) : React.createElement('ul', null),
        React.createElement(
            'button',
            { onClick: function onClick() {
                    return setErtek(function (elozo) {
                        return elozo + 10;
                    });
                } },
            'N\xF6vel\xE9s'
        ),
        React.createElement(
            'button',
            { onClick: function onClick() {
                    return setErtek(function (elozo) {
                        return elozo - 10;
                    });
                } },
            'Cs\xF6kkent\xE9s'
        ),
        React.createElement(
            'button',
            { onClick: function onClick() {
                    return setErtek(0);
                } },
            'Alap\xE9rt\xE9k'
        ),
        React.createElement(
            'button',
            { onClick: function onClick() {
                    return setLathato(!lathato);
                } },
            'Lista kapcsol\xE1s'
        )
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('app-container'));