const readline = require("readline");

const mapWidth = 48;
const mapHeight = 16;
const sectorDensity = 0.17;
const delta = 1;

const stars = [];

function getRandomInt(max) {
  return Math.floor(Math.random() * Math.floor(max));
}

for (let i = 0; i < mapHeight; i++) {
  stars[i] = [];
  for (let j = 0; j < mapWidth; j++) {
    stars[i][j] = 0;
  }
}

const starCount = Math.ceil(sectorDensity * mapHeight * mapHeight) + delta;
for (let i = 0; i < starCount; i++) {
  const coordX = getRandomInt(mapWidth);
  const coordY = getRandomInt(mapHeight);
  stars[coordY][coordX] = 1;
}
// console.log(stars)
for (let i = 0; i < mapHeight; i++) {
  let visualLine = '';
  for (let j = 0; j < mapWidth; j++) {
    visualLine += stars[i][j] ? '0' : ' '
  }
  console.log(visualLine);
}
