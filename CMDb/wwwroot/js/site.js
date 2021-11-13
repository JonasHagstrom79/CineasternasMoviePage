const baseUrl = 'https://grupp9.dsvkurs.miun.se/api/'


function showPlot() {
    let dots = document.getElementById("dots");
    let moreText = document.getElementById("more");
    let btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
    btnText.innerHTML = "Read more";
    moreText.style.display = "none";
  } else {
        dots.style.display = "none";
    btnText.innerHTML = "Read less";
    moreText.style.display = "inline";
  }
}

document.getElementById("like").addEventListener("click", async () => {
    let id = document.getElementById("like").accessKey;
    let request = await fetch(`${baseUrl}${id}/like`)
    let data = await request.json()
    document.getElementById("upvote").innerHTML = (`Likes ${data.numberOfLikes}`)
    like.disabled = true
    dislike.disabled = true
    document.getElementById('like').style.color = '#8cff66';
    document.getElementById('like').style.backgroundColor = 'darkgreen';
    document.getElementById('like').style.opacity = 0.9;
    document.getElementById('dislike').style.colorInterpolation = '#ff6666';
    document.getElementById('dislike').style.opacity = 0.3;

})

document.getElementById("dislike").addEventListener("click", async () => {
    let id = document.getElementById("dislike").accessKey;
    let request = await fetch(`${baseUrl}${id}/dislike`)
    let data = await request.json()
    document.getElementById("downvote").innerHTML = (`Dislikes ${data.numberOfDislikes}`)
    dislike.disabled = true
    like.disabled = true
    document.getElementById('dislike').style.colorInterpolation = '#ff6666';
    document.getElementById('dislike').style.backgroundColor = "darkred"
    document.getElementById('dislike').style.opacity = 0.9;
    document.getElementById('like').style.colorInterpolation = '#ff6666';
    document.getElementById('like').style.opacity = 0.3;
})


