const app = getApp();
var util = require('../../../utils/util.js');
Page({

  /**
   * 页面的初始数据
   */
  data: {
    num: 1,
    goods: {},
    sessionKey: '',
    totalNum: 0,
    hasCarts: false,
    curIndex: 0,
    show: false,
    scaleCart: false,
    menuId: ''
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var self = this;
    wx.request({
      url: app.globalData.urlMenu + '?menuId=' + options.menuId,
      success: function(res) {
        self.setData({
          goods: res.data.Context,
          menuId: options.menuId
        });
        //console.log(self.data.goods);
      }
    })
  },

  addCount() {
    let num = this.data.num;
    num++;
    this.setData({
      num: num
    })
  },

  minusCount() {
    let num = this.data.num;
    num--;
    if (num <= 1) {
      num = 1
    }
    this.setData({
      num: num
    })
  },

  addToCart() {
    const self = this;
    const num = this.data.num;
    wx.request({
      url: app.globalData.urlCarts,
      data: {
        menuId: this.data.menuId,
        count: num,
        sessionKey: app.globalData.sessionKey
      },
      method: 'POST',
      success: function(res) {
        console.log(res);
      }
    })

    //app.globalData.carts.push(self.data.goods);
    let total = this.data.totalNum;
    if (num == 0) {
      return
    }
    self.setData({
      show: true
    })
    setTimeout(function() {
      self.setData({
        show: false,
        scaleCart: true
      })
      setTimeout(function() {
        self.setData({
          scaleCart: false,
          hasCarts: true,
          totalNum: num + total
        })
      }, 200)
    }, 300)
  },

  bindTap(e) {
    const index = parseInt(e.currentTarget.dataset.index);
    this.setData({
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
  onShow: function() {

  },

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