Vue.component('ShowMeTheCodeComponent', {
    template: `<main role="main" style="background-color:darkgray !important; color:white !important">

        <div class="jumbotron" style="background-color: dimgray !important; color: white !important; text-align:center; margin-top: 10px !important; margin-bottom: 80px !important">
            <div class="container">
                <h6>Show Me The Code</h6>
                <br />
                <br />
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-12">Clique no link</div>
                <div class="col-md-12"><router-link to="/" @click.native="geturl" class="btn btn-secondary">GET INFO URL</router-link></div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">URL código no Github</div>
                <div class="col-md-3" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
                    <div style="background-color: white !important; ">
                        <div class="card mb-4 shadow-sm">
                            <div class="card-header">
                                <span></span>
                            </div>
                            <div class="card-body">
                                <span>{{ conteudo }}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr>
        </div>

    </main>`,
    data: function () {
        return {
            conteudo: null,
        }
    },
    mounted: function () {
    },
    methods: {
        geturl: function (event) {
            axios.get('http://localhost:52367/api/showmethecode')
                .then(response => {
                    this.conteudo = response.data.urlGitHub;
            })
            .catch(error => {
                console.log(error)
                this.errored = true
            })
        }
    }
})

