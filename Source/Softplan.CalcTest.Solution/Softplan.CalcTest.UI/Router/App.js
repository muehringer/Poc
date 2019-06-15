const ShowMeTheCodeComponent = { template: '<ShowMeTheCodeComponent></ShowMeTheCodeComponent>' }

const routes = [
    { path: '/showmethecode', component: ShowMeTheCodeComponent },
    { path: '*', redirect: '/showmethecode' }
]

const router = new VueRouter({
    routes
})

var app = new Vue({
    router
}).$mount('#app')
