export interface IComment{
    commentId : number,
    text : string,
    postedOn : string,
    authorName : string,
    authorPhoto : string,
    replies : IComment[]
}