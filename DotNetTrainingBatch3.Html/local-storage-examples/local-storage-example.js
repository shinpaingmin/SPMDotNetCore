const tblBlog = "TblBlog";

runBlog();

function runBlog() {

    const id = prompt("Id");
    const title = prompt("Title");
    const author = prompt("Author");
    const content = prompt("Content");
    updateBlog(id, title, author, content);
    // createBlog("James Bond", "007", "A spy");
    // createBlog(title, author, content);
    // readBlog();
    // editBlog("1");
    // editBlog("ba8d5d22-f331-4fa4-95c1-750b94149cc8");
    // deleteBlog("ba8d5d22-f331-4fa4-95c1-750b94149cc8");

}

function readBlog() {
    const lst = getBlog();

    if(lst.length === 0) {
        console.log("No blog found");
        return;
    }

    lst.forEach(item => {
        console.log(item.Title);
        console.log(item.Author);
        console.log(item.Content);
    });
}

function editBlog(id) {
    let lst = getBlog();

    let blogLst = lst.filter(x => x.Id == id);

    if(blogLst.length === 0) {
        console.log("no data found");
        return;
    }

    let blog = blogLst[0];
    console.log(blog)
}

function createBlog(title, author, content) {
    const lst = getBlog();

    const blog = {
        Id: uuidv4(),
        Title: title,
        Author: author,
        Content: content
    };

    lst.push(blog);
    formatJson(lst);
}

function updateBlog(id, title, author, content) {
    let lst = getBlog();

    let index = lst.findIndex(x => x.Id == id);

    if(!index) {
        console.log("No data found");
        return;
    }

    lst[index] = {
        Id: id,
        Title: title,
        Author: author,
        Content: content
    };

    formatJson(lst);
    console.log("Success");
}

function deleteBlog(id) {
    let lst = getBlog();

    let blogs = lst.filter(x => x.Id == id);

    if(blogs.length === 0) {
        console.log("No data found");
        return;
    }

    let bloglst = lst.filter(x => x.Id != id);

    formatJson(bloglst);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlog() {
    let lst = [];
    const jsonBlog = localStorage.getItem(tblBlog);
    if(jsonBlog) {
        lst = JSON.parse(jsonBlog);
    }
    return lst;
}

function formatJson(blog) {
    const blogStr = JSON.stringify(blog);
    localStorage.setItem(tblBlog, blogStr);
}