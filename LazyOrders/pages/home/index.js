const app = getApp()
var util = require('../../utils/util.js');
Page({

  /**
   * 页面的初始数据
   */
  data: {
    movies: [{
        url: app.globalData.url + '?fileName=1.jpg'
      },
      {
        url: app.globalData.url + '?fileName=2.jpg'
      },
      {
        url: app.globalData.url + '?fileName=3.jpg'
      }
    ],
    navLeftItems: [],
    navRightItems: [],
    curNav: 1,
    curIndex: 0
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var _this = this;
    util.checkSession();
    wx.request({
      url: app.globalData.urlCategory,
      success: function(res) {
        _this.setData({
          navLeftItems: res.data.Context,
          navRightItems: res.data.Context
        })
      }
    })

  },

  //事件处理函数  
  switchRightTab: function(e) {
    // 获取item项的id，和数组的下标值  
    let id = e.target.dataset.id,
      index = parseInt(e.target.dataset.index);
    console.log(id);
    console.log(index);
    // 把点击到的某一项，设为当前index  
    this.setData({
      curNav: id,
      curIndex: index
    })
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {},

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})