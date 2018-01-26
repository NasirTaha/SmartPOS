import Comment from "/Comment";


class CommentList extends React.Component {
    render() {
        var commentNodes = this.props.data.map(function (comment) {
            return (
                <Comment author={comment.author} key={comment.id}>
                    {comment.text}
                </Comment>
            );
        });
        return (
            <div className="commentList">
                {commentNodes}
            </div>
        );
    }
}


class CommentForm extends React.Component{
    state = {
        author: '', text: ''
    };
  

    handleAuthorChange = (e) => {
        this.setState({ author: e.target.value });
    }

    handleTextChange = (e) => {
        this.setState({ text: e.target.value });
    }

    handleSubmit = (e) => {
        e.preventDefault();
        var author = this.state.author.trim();
        var text = this.state.text.trim();
        if (!text || !author) {
            return;
        }
        // TODO: send request to the server
        this.props.onCommentSubmit({ author: author, text: text });
        this.setState({ author: '', text: '' });
    }

    render() {
        return (
            <form className="commentForm" onSubmit={this.handleSubmit}>
                <input
                    type="text"
                    placeholder="Your name"
                    value={this.state.author}
                    onChange={this.handleAuthorChange}
                />
                <input
                    type="text"
                    placeholder="Say something..."
                    value={this.state.text}
                    onChange={this.handleTextChange}
                />
                <input type="submit" value="Post" />
            </form>
        );
    }
}


class CommentBox extends React.Component{
    constructor() {
        super();
        this.state = {
            url: "/comments",
            submitUrl: "/comments/new",
            pollInterval: 2000,
            data: []
        };
        
    }
    loadCommentsFromServer() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.state.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    }

    handleCommentSubmit = (comment) => {
        var data = new FormData();
        data.append('author', comment.author);
        data.append('text', comment.text);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.state.submitUrl, true);
        xhr.onload = function () {
            this.loadCommentsFromServer();
        }.bind(this);
        xhr.send(data);
    }

    

    componentWillMount() {
        this.loadCommentsFromServer();
    }

    componentDidMount() {
        this.loadCommentsFromServer();
       // window.setInterval(this.loadCommentsFromServer, this.pollInterval);
    }

   
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
                <CommentForm onCommentSubmit={this.handleCommentSubmit} />
            </div>
        );
    }
}
ReactDOM.render(
    //<CommentBox url="/comments" submitUrl="/comments/new" pollInterval={2000} />,
    <CommentBox />,
    document.getElementById('testReact')
);
//class CommentBox extends React.Component {
//    render() {
//        return (
//            <div>
//                <h1> Salam alicom </h1>
//            </div>
//        );
//    }
//}

//ReactDOM.render(
//    <CommentBox />,
//    document.getElementById('testReact')
//);