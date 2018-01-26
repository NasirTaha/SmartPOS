//ReactDOM.render(
//    <div>
//        <h1>Hello World!</h1>
//    </div>,
//    document.getElementById('helloworldcontainer')
//);


//---------------------
var App = React.createClass({

    //getInitialState: function () {
    //    return { data: '' };
    //},
    //componentWillMount: function () {
    //    var xhr = new XMLHttpRequest();
    //    xhr.open('get', this.props.url, true);
    //    xhr.onload = function () {
    //        var response = JSON.parse(xhr.responseText);
    //        console.log("React Log " + xhr.responseText);
    //        this.setState({ data: xhr.responseText/*User This When we use object response.result*/ });
    //    }.bind(this);
    //    xhr.send();
    //},

    render: function () {
        //console.log("React Reanser " + this.data);
        //return (
        //    <h2>{this.state.data}</h2>
        //);
        return (
            <div className="commentBox">
                Hello, world! I am a CommentBox.
      </div>
        );
    }
});
$(document).ready(function () {
    ReactDOM.render(<App/>, document.getElementById('helloworldcontainer'));
});
//React.render(<App url="/Home/GetMessage" />, document.getElementById('helloworldcontainer'));
//ReactDOM.render(<App url="/Home/GetMessage" />, document.getElementById('helloworldcontainer'));