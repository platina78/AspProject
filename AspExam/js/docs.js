let test = true; //db에서 새로만든 페이지인지확인하고 저장하게 되면 db의 데이터 값을 false로
//단발적 데이터


//console.log('show Data',serverData);

const doc_editor = new EditorJS({
    holderId: 'editorjs',
    autofocus: true,
    tools: {
        header: {
            class: Header,
            inlineToolbar: ['link']
        },
        list: {
            class: List,
            inlineToolbar: [
                'link',
                'bold'
            ]
        },
        embed: {
            class: Embed,
            inlineToolbar: false,
            config: {
                youtube: true,
                coub: true
            }
        },
        quote: {
            class: Quote,
            inlineToolbar: true,
        }, image: SimpleImage,

    },
    data: {
        time: new Date(),
        blocks: serverData ? serverData : ""
    }
});

document.addEventListener("keydown", e => { //이슈 회피
    if (e.keyCode == 222) {
        e.preventDefault();
    }
});


//editor.data.blocks[0].data.text="test"



/*
    기능 :
    저장을 한다. 어떤거? time blocks
    새로 만들기를 하면 insert  할 때에 data도 같이 들어간다.
    pageLoad가 될 경우 현재 작성한 docs에서 데이터를 볼 수 있다. select해서 긁어 오기
    c#으로 js에서 남긴 데이터를 받고 
    
    문제점?
    json형식의 데이터를 c#의 insert함수안의 parameter값으로 받아와서

    json형식의 데이터를 db에 넣도록 하도록 한다.
    
    이모티콘을 넣기 위해서 nvarchar을 사용해야 함
    time은 그냥 숫자로 넣어도 상관 없음
    id는 생긴 순서대로 걍 넣기
    
 
 
*/
//데이터 나눌 때 {} 객체, [] 배열
//editor.data.time,
//editor.data.blocks.map((v)=>v);

let saveBtn = document.querySelector('#docs_save');
let addBtn = document.querySelector('#docs_add');

