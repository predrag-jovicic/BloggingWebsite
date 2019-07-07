export class QueryParam{
    category : string;
    tag : string;
    searchQuery : string;
    pageNumber : number;
    constructor(category,tag,searchQuery,pageNumber){
        this.category = category;
        this.tag = tag;
        this.searchQuery = searchQuery;
        this.pageNumber = pageNumber;
    }
}