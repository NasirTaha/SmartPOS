import CommentList from './CommentList';
import CommentForm from './CommentForm';

export default class CommentBox extends React.Component {
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
   

    handleCommentSubmit = (comment) =>{
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
                <CommentForm onCommentSubmit={this.handleCommentSubmit.bind(this)} />
            </div>
        );
    }
}