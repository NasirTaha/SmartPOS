﻿export default class Comment extends React.Component {
    //rawMarkup(){
    //    var md = new Remarkable();
    //    var rawMarkup = md.render(this.props.children.toString());
    //    return { __html: rawMarkup };
    //}

    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">
                    {this.props.author}
                </h2>
                <h1>
                    {this.props.children}
                </h1>
            </div>
        );
    }
}