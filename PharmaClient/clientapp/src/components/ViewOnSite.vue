<template>
<div id="app1">

    <v-autocomplete
    v-model="autovalue"
      :disabled="this.ifdisabled"
      @change="counter($event)"
      :items="entries"
      :search-input.sync="search"
      :loading="loadingvariable"
      loading-text="Loading... Please wait"
      placeholder="Search by Drug Name"
      class="search"
    prepend-icon="mdi-database-search">
     <template v-slot:append-item>
          <v-divider class="mb-2"></v-divider>
          <v-list-item>
             <v-btn
                color="primary"
                dark
                class="ma-2"
                @click="opendialog()"
              >
                Open Dialog 2
              </v-btn>
  
          </v-list-item>
        </template>
        </v-autocomplete>
   

   
</div>
</template>

<script>

// export default
// {
//   name:'ViewOnSite',
//   mounted: function() {
//     this.fetchData();
//     if (alert) {
//       this.hide_alert();
//     }
//   },
//    methods:{  
//        fakeServer: function(search) {
//   return new Promise(resolve => {
//     setTimeout(() => {
//       resolve([
//         'Red', 'Yellow', 'Green', 'Brown', 'Blue', 'Pink', 'Black'
//       ].filter(c => c.toLowerCase().includes(search.toLowerCase())))
//     }, 1000)
//   }) 
// },

//   loadEntries: async function () {
//       this.entries = await this.fakeServer(this.queryTerm || '')
//     }
//   },

//   fetchData: function() {
//       // I prefer to use fetch
//       // you can use use axios as an alternative

//       const headers = new Headers();
//       headers.append("Authorization", "api_key");
//       const request = new Request(
//         "https://localhost:5001/api/pharma/View",
//         {
//           method: "GET",
//           headers,
//           mode: "cors",
//           cache: "default",
//           body:
//           {
//     DesignDocumentName : "ProductName",
//     ViewName : "ProductName-view",
//     Filters : {
//         limit : "100",
//         skip : "0",
//         startkey : "12-",
//         endkey :"12-\ufff0"
//     }
// }

//         }
//       );

//       return fetch(request)
//         .then((res) => {
//           // a non-200 response code
//           console.log(res);
//           if (!res.ok) {
//             console.log(res);
//             // create error instance with HTTP status text
//             const error = new Error(res.statusText);
//             // error.json = res.json();
//             console.log(error);
//             throw error;
//           }

//           return res.json();
//         })
//         .then((json) => {
//           // set the response data
//           //this.data = json;
//           this.items = json.pharmaDetails;
//           this.loadingvariable = false;
//         })
//         .catch((err) => {
//           console.log(err);
//           this.error = err;
//           // In case a custom JSON error response was provided
//           if (err.json) {
//             console.log(err);
//             return err.json.then((json) => {
//               // set the JSON response message
//               this.error.value = json.message;
//             });
//           }
//         })
//         .then(() => {
//           this.loadingvariable = false;
//         });
//     },
  

 


//   computed: {
//     search: {
//       get () {
//         return this.queryTerm
//       },
      
//       set (searchInput) {
//         if (this.queryTerm !== searchInput) {
//           this.queryTerm = searchInput
//           this.loadEntries()
//         }
//       }
//     }
//   },
  
//   created () {
//     this.loadEntries()
//   }

  


// }
 
export default {
 
        name: 'OnSiteApp',
        props: ['ifdisabled'],
         
        data: () => ({
        dialog2:false,
      entries: [],
      queryTerm: '',
    loadingvariable:false,
    disabledvalue: false
        }),


    methods:
    {
      addmore:function()
      {
console.log(this.autovalue,'addmore')

      },
      clickfunction:function()
      {
console.log('click')
      },

 
  fetchdata: function(queryterm)
              {            
                  console.log(this.ndc,'sadsad');
      const request = new Request(
        "https://localhost:5001/api/pharma/View",
        {
          method: 'POST',
           headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          contentType: "application/json",
        },
          mode: "cors",
          cache: "no-cache",
          body: JSON.stringify(
          {
    DesignDocumentName : "ProductName",
    ViewName : "ProductName-view",
    
    Filters : {
        limit : "100",
        skip : "0",
        startkey : queryterm,
        endkey :queryterm+'\ufff0'
    }
})

        }
      );

      return fetch(request)
        .then((res) => {
         
          console.log(res);
          if (!res.ok) {
            console.log(res);
            
         
            const error = new Error(res.statusText);
            error.json = res.json();
            console.log(error);
            throw error;
          }

         return res.json();
        })
        .then((json) => {
          console.log(this.queryTerm, 'input')
         console.log(json,'yeah')
          //this.entries =[json.rows[0].value.dProductName,  json.rows[6].value.dProductName];
            json.rows.reduce((temp, value) => {
          if(temp.length<10)
           temp.push(value);
          return temp;
           }, []);
         this.entries =  json.rows.map((row)=>row.value.dProductName)
        this.loadingvariable = false;
        })
        .catch((err) => {
          console.log(err);
          this.error = err;
        
          if (err.json) {
            console.log(err);
            return err.json.then((json) => {
             
              this.error.value = json.message;
            });
          }
        })
        .then(() => {
          this.loadingvariable = false;
          console.log(this.entries,'yeah')
          return this.entries;        
        });
    
    },

     counter: function(value)
              {

                console.log(value,'tocheck')
                  
                 
      const request = new Request(
        "https://localhost:5001/api/pharma/View",
        {
          method: 'POST',
           headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          contentType: "application/json",
        },
          mode: "cors",
          cache: "no-cache",
          body: JSON.stringify(
          {
    DesignDocumentName : "ProductName",
    ViewName : "ProductName-view",
    
    Filters : {
        limit : "100",
        skip : "0",
        startkey : value,
        endkey :value+'\ufff0'
    }
})

        }
      );

       return fetch(request)
        .then((res) => {
         
          console.log(res);
          if (!res.ok) {
            console.log(res);
            
         
            const error = new Error(res.statusText);
            error.json = res.json();
            console.log(error);
            throw error;
          }

         return res.json();
        })
        .then((json) => {
          console.log(this.queryTerm, 'input')
         console.log(json.rows[0].value.dManName,'counter yeah')
          //this.entries =[json.rows[0].value.dProductName,  json.rows[6].value.dProductName];
          this.$store.dispatch('ActionAppIncrement1', {
  manufacturer: json.rows[0].value.dManName,
  size: json.rows[0].value.dManName.substring(0,5),
  strength: json.rows[0].value.dStrength.substring(0,5),
   dosage: json.rows[0].value.dManName.substring(0,5),
    controlnumber: json.rows[0].value.dManName.substring(0,5),
    returnable: json.rows[0].value.dManName.substring(0,5),
    repacked: json.rows[0].value.dManName.substring(0,5),
})
            
        this.loadingvariable = false;
        })
        .catch((err) => {
          console.log(err);
          this.error = err;
        
          if (err.json) {
            console.log(err);
            return err.json.then((json) => {
             
              this.error.value = json.message;
            });
          }
        })
        .then(() => {
          this.loadingvariable = false;
          console.log(this.entries,'yeah')
          return this.entries;        
        });
    
    },

  loadEntries: async function () {
    if(this.queryTerm.length>=2)   
      this.entries = await this.fetchdata(this.queryTerm)
      else
      this.entries = [];   
  },

    },
        computed: {
    search: {
      get () {
        return this.queryTerm
      },
      
      set (searchInput) {
        if (this.queryTerm !== searchInput) {
         
          this.queryTerm = searchInput
          this.loadEntries()
        }
      }
    }
  },
  
  created () {
    this.loadEntries()
  },
  mounted(){
     this.disabledvalue = this.ifdisabled;
     console.log(this.disabledvalue,'comp val')
},

   watch: {
    search (val) {
    
      if(val=='')
      {

         this.$store.dispatch('ActionAppIncrement1', {
  manufacturer: '',
  size: '',
  strength: '',
   dosage: '',
    controlnumber:'',
    returnable: '',
    repacked: '',
});
      }

         if(val)
    this.loadingvariable = true;

    }
  }

  


}
 
        
        
        
            

</script>

<style>

.search
{



border-radius: 4px;
 width:840px;

}

</style>
